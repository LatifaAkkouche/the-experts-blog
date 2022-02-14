using ExpertsBlog.Api.Data;
using ExpertsBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertsBlog.Api.Controllers
{
    public class Repository<T>
        where T : EntityBase, new()
    {
        private readonly ExpertsBlogDbContext Context;

        public Repository(ExpertsBlogDbContext context) => this.Context = context;

        [HttpGet]
        public virtual IQueryable<T> GetQuery(string? search)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            if (string.IsNullOrWhiteSpace(search))
            {
                //query.Where(e => e)
            }
            return query;
        }

        [HttpGet("{id?}")]
        public virtual async Task<T?> GetAsync(int? id)
        {
            if (id.HasValue)
            {
                return await Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == id.Value);
            }
            return null;
        }

        [HttpPost]
        public virtual async Task<T?> CreateAsync(T t)
        {
            if (t is not null)
            {
                Context.Set<T>().Add(t);
                await Context.SaveChangesAsync();
                return t;
            }
            return null;
        }

        [HttpPut]
        public virtual async Task<T?> UpdateAsync(int id, T t)
        {
            if (t is not null && id == t.Id)
            {
                Context.Set<T>().Update(t);
                await Context.SaveChangesAsync();
                return t;
            }
            return null;
        }

        [HttpDelete]
        public virtual async Task<T?> Delete(int? id)
        {
            if (id.HasValue)
            {
                T t = await this.GetAsync(id.Value);
                if (t is not null)
                {
                    t.IsDeleted = true;
                    return await this.UpdateAsync(id.Value, t);
                }
            }
            return null;
        }

        [HttpDelete]
        public virtual async Task<T?> Undelete(int? id)
        {
            if (id.HasValue)
            {
                T t = await this.GetAsync(id.Value);
                if (t is not null)
                {
                    t.IsDeleted = false;
                    return await this.UpdateAsync(id.Value, t);
                }
            }
            return null;
        }
    }
}

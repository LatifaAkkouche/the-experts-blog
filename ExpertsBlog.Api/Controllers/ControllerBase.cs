﻿using ExpertsBlog.Data;
using ExpertsBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ExpertsBlog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerBase<T> : ControllerBase
        where T : EntityBase, new()
    {
        private readonly Repository<T> Repository;

        public ControllerBase(Repository<T> repository) => this.Repository = repository;

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get(string? search)
        {
            IQueryable<T> query = Repository.GetQuery(search);
            if (string.IsNullOrWhiteSpace(search))
            {
                //query.Where(e => e)
            }
            return await query.ToListAsync();
        }

        [HttpGet]
        public virtual async Task<T?> Get(int? id)
        {
            if (id.HasValue)
            {
                return await Repository.GetAsync(id.Value);
            }
            return null;
        }

        [HttpPost]
        public virtual async Task<T?> Post([FromBody]T t)
        {
            if (t is not null)
            {
                return await Repository.CreateAsync(t);
            }
            return null;
        }

        [HttpPut]
        public virtual async Task<T?> Put(int id, [FromBody]T t)
        {
            if (t is not null && id == t.Id)
            {
                return await Repository.UpdateAsync(id, t);
            }
            return null;
        }

        [HttpDelete]
        public virtual async Task<T?> Delete(int? id)
        {
            if (id.HasValue)
            {
                T t = await Repository.GetAsync(id.Value);
                if (t is not null)
                {
                    t.IsDeleted = true;
                    return await Repository.UpdateAsync(id.Value, t);
                }
            }
            return null;
        }

        [HttpDelete]
        public virtual async Task<T?> Undelete(int? id)
        {
            if (id.HasValue)
            {
                T t = await Repository.GetAsync(id.Value);
                if (t is not null)
                {
                    t.IsDeleted = false;
                    return await Repository.UpdateAsync(id.Value, t);
                }
            }
            return null;
        }
    }
}
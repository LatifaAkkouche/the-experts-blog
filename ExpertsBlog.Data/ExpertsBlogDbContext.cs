using ExpertsBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertsBlog.Data
{
    public class ExpertsBlogDbContext : DbContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }

        public ExpertsBlogDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
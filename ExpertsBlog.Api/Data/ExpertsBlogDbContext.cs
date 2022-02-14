using ExpertsBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertsBlog.Api.Data
{
    public class ExpertsBlogDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ExpertsBlogDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
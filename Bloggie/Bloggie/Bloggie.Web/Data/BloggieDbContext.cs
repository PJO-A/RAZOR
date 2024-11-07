using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
            

        }

        // properties to represent domain model
        public DbSet<BlogPost> BlogPosts { get; set; }  //DbSet of type: BlogPost , BlogPosts - name from SQL
        public DbSet<Tag> Tags { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MyBlogProject_Frontend.Models
{
    public class ConsumerDbContext:DbContext
    {
        public ConsumerDbContext()
        {

        }

        public ConsumerDbContext(DbContextOptions<ConsumerDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}

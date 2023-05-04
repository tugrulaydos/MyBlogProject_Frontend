using Microsoft.EntityFrameworkCore;
using MyBlogProject_Frontend.Models.Entities;

namespace MyBlogProject_Frontend.Models.Context
{
    public class ConsumerDbContext : DbContext
    {
        public ConsumerDbContext()
        {

        }

        public ConsumerDbContext(DbContextOptions<ConsumerDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<About> AboutUs { get; set; }

        public DbSet<Contact> Contact { get; set; }

    }
}

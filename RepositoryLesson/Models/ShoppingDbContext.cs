using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace RepositoryLesson.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) {}

        public DbSet<Users> Users { get; set; }
        public DbSet<Lists> Lists { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }


}

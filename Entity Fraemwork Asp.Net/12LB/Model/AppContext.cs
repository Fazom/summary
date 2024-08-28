using Microsoft.EntityFrameworkCore;

namespace _12LB.Model
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host = localhost; port = 5432; database = TestEntity; username = postgres; password = yalokin4002");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

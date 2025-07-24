using BaseProjectTemplate._1.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace BaseProjectTemplate._2.DataAccessLayer.EF_Core
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DemoClass> DemoClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account
            modelBuilder.Entity<DemoClass>()
                .HasKey(a => a.Id);
        }
    }
}

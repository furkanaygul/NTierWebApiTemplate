using BaseProjectTemplate._1.EntityLayer.Concreate;
using BaseProjectTemplate._2.DataAccessLayer.EF_Core;
using Microsoft.EntityFrameworkCore;
namespace BaseProjectTemplate._6.Extensions
{
    public static class DbInitializer
    {
        public static void ApplyMigrationsAndSeed(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.Migrate(); // veritabanını oluştur ve migrationları uygula

            // SeedInitialData(db);   // opsiyonel seed işlemi
        }

        private static void SeedInitialData(AppDbContext db)
        {
            // örnek: varsayılan veriler
            if (!db.DemoClasses.Any())
            {
                db.DemoClasses.Add(new DemoClass()
                {
                   Id = Guid.NewGuid(),
                   Name = "Initial Demo Class"
                });

                db.SaveChanges();
            }
        }
    }
}

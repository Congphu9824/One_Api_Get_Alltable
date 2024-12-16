using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.AppicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TUM2DU4\\SQLEXPRESS01;Database=Test_oneApi_Get_AllTable;Trusted_Connection=True;TrustServerCertificate =True");
        }
    }
}

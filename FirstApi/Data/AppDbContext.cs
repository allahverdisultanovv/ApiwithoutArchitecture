using FirstApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }



    }
}

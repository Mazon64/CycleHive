using Microsoft.EntityFrameworkCore;

namespace CycleHive.Models
{
    public class CycleHiveDbContext : DbContext
    {
        public CycleHiveDbContext(DbContextOptions<CycleHiveDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
    }
}
using System.Data.Entity;
using WebAPI1.Models;

namespace WebAPI1.Database
{
    public class PrimaryDbContext : DbContext
    {
        public PrimaryDbContext() : base("name=PrimaryDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

    }


}

using System.Data.Entity;
using XPTO.Repository.Entities;

namespace XPTO.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        
    }
}

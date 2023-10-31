using InventoryManagement.Entity.Master;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class CIDBContext : DbContext
    {
        public CIDBContext(DbContextOptions<CIDBContext> options) : base(options)
        {

        }
        public DbSet<ProductEntity>? Product { get; set; }
    }
}

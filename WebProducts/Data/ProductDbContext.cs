using System.Data.Entity;
using WebProducts.Models;

namespace WebProducts.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("KeyProducts") { }
        public DbSet<Product> Products { get; set; }
    }
}
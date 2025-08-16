using Microsoft.EntityFrameworkCore;
using srv_products.Models;

namespace srv_products.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products {  get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected AppDbContext()
        {
        }
    }
}

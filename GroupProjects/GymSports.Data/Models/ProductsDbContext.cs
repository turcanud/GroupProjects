using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GymSports.Data.Models
{
     public class ProductsDbContext : DbContext
     {
        public ProductsDbContext() : base("GymPurchaseDataBase")
        {
            
        }
          public DbSet<GymProduct> GymProducts { get; set; }
          public DbSet<CartItem> CartItems { get; set; }
          public DbSet<Cart> Carts { get; set; }

     }
}

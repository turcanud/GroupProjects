using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GymSports.Data.Models
{
     public class GymDbContext : DbContext
     {
        public GymDbContext() : base("GymDataBaseStack")
        {
            
        }
        public DbSet<GymPlace> GymPlaces { get; set; }
          public DbSet<GymProduct> GymProducts { get; set; }
     }
}

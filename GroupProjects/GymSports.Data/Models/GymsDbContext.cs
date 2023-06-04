using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Models
{
     public class GymsDbContext : DbContext
     {
        public GymsDbContext() : base("GymPlacesDataBase")
        {
            
        }
        public DbSet<GymPlace> GymPlaces { get; set; }

     }
}

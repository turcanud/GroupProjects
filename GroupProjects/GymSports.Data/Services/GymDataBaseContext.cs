using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Services
{
     public class GymDataBaseContext : DbContext
     {

          public DbSet<Gyms> GymsDb { get; set; }
     }
}

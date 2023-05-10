using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Models
{
     public class Gyms
     {
          public int Id { get; set; }
          [Required]
          [MaxLength(69)]
          public string Name { get; set; }
          [Required]
          public RegionList Region { get; set; }
          [Required]
          [MaxLength(69)]
          public string Address { get; set; }
    }
}

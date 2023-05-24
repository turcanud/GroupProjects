using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymSports.Data.Models
{
     public partial class GymPlace
     {
          [Key]
          public int GymID { get; set; }
          [Required]
          [MaxLength(20, ErrorMessage ="The name has to be less than 20 characters.")]
          [MinLength(4, ErrorMessage = "The name has to contain more than 4 characters.")]
          public string Name { get; set; }
          [Required]
          public string Region { get; set; }
          [Required]
          [MaxLength(69)]
          [MinLength(6, ErrorMessage = "The Address has to contain more than 6 characters.")]
          public string Address { get; set; }
     }
}

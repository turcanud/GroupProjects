using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymSports.Data.Models
{
     public partial class GymProduct
     {
          [Key]
          public int ProductID { get; set; }
          [Required]
          [MaxLength(20, ErrorMessage = "The name has to be less than 20 characters.")]
          [MinLength(4, ErrorMessage = "The name has to contain more than 4 characters.")]
          public string Name { get; set; }
          [Required]
          [MaxLength(20, ErrorMessage = "The Category has to be less than 20 characters.")]
          [MinLength(4, ErrorMessage = "The Category has to contain more than 4 characters.")]
          public string Category { get; set; }
          [Required]
          public Nullable<decimal> Price { get; set; }
          [Required]
          public string AvailabilityStatus { get; set; }
          [Required]
          [MaxLength(20, ErrorMessage = "The Brand Name has to be less than 20 characters.")]
          [MinLength(4, ErrorMessage = "The Brand Name has to contain more than 4 characters.")]
          public string Brand { get; set; }

          public string Photo { get; set; }
     }
}

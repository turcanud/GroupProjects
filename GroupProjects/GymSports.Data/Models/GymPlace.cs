using System;
using System.ComponentModel.DataAnnotations;

namespace GymSports.Data.Models
{
     public class GymPlace
     {
          [Key]
          public int GymID { get; set; }

          [Required(ErrorMessage = "Name and surname are required.")]
          [StringLength(20, MinimumLength = 4, ErrorMessage = "The name should be between 4 and 20 characters.")]
          public string NameSurname { get; set; }

          [Required(ErrorMessage = "Region is required.")]
          [StringLength(50, ErrorMessage = "The region should be up to 50 characters.")]
          public string Region { get; set; }

          [Required(ErrorMessage = "Date is required.")]
          [DataType(DataType.Date)]
          [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
          public DateTime Date { get; set; }

          [Required(ErrorMessage = "Time is required.")]
          public string Time { get; set; }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Models
{
     public class Cart
     {
          public string CartID { get; set; }
          public string UserID { get; set; }
          public List<CartItem> CartItems { get; set; }
     }

}

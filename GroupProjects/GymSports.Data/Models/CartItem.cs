using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Models
{
     public class CartItem
     {
          public int CartItemID { get; set; }
          public string CartID { get; set; }
          public int ProductID { get; set; }
          public int Quantity { get; set; }
          public decimal Subtotal
          {
               get { return Quantity * (Product.Price ?? 0); }
          }
          public virtual GymProduct Product { get; set; }
     }


}

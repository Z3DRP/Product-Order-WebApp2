using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class CartViewModel
    {
        public IEnumerable<CartProduct> ProductList { get; set; }
        public double Subtotal { get; set; }       
    }
}

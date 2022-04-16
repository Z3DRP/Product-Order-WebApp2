using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class Cart
    {
        public int CustomerID { get; set; }
        public List<OrderedProduct> Products { get; set; }
    }
}

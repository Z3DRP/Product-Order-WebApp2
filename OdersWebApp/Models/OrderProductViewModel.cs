using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class OrderProductViewModel : ProductViewModel
    {
        public OrderedProduct Products { get; set; }
        public Customer Customer { get; set; }
        public double GetOrderTotal()
        {
            double total;

            if (Products.Quantity > 0)
                total = (double)(Products.UnitPrice * Products.Quantity);
            else
                total = Products.UnitPrice;

            return total;
        }

    }
}

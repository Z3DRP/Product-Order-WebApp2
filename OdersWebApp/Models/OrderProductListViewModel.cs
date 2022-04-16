using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class OrderProductListViewModel : OrderProductViewModel
    {
        public Customer Customer { get; set; }
        public List<OrderedProduct> Products { get; set; }
        public double GetOrderPrice()
        {
            double price = 0;
            double pricePerItem = 0;

            foreach(OrderedProduct op in Products)
            {
                pricePerItem = (double)(op.UnitPrice * op.Quantity);
                price += pricePerItem;
            }
            return price;
        }
    }
}

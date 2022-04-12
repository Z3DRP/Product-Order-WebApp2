using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdersWebApp.Models
{
    public class CustomerProductsViewModel
    {
        private OrderContext context { get; set; }

        public CustomerProductsViewModel(OrderContext pctx)
        {
            context = pctx;
        }

        public string CustomerName { get; set; }
        public List<Product> CustomerProducts { get; set; }

        public int GetCustomerId(string name)
        {
            int id;
            Customer customer = context.Customers.FirstOrDefault(c => c.CustomerFullName == name);
            id = customer.CustomerID;

            return id;
        }
    }
}

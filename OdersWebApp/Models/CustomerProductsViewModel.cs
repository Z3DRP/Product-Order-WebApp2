using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class CustomerProductsViewModel
    {
        public string CustomerName { get; set; }
        public List<Product> CustomerProducts { get; set; }

    }
}

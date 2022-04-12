using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class CustomerOrdersViewModel
    {
        public string CustomerName { get; set; }
        public List<int> OrderIds { get; set; }

    }
}

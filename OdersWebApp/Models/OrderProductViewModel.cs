using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class OrderProductViewModel
    {
        public OrderedProduct Products { get; set; }
        public Customer Customer { get; set; }

    }
}

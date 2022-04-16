using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class ProductListViewModel : ProductViewModel
    {
        public string Username { get; set; }
        public List<OrderedProduct> SelectedProducts { get; set; }

    }
}

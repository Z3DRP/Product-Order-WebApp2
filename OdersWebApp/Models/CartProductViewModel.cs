using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class CartProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Slug => Name?.Replace(' ', '-').ToLower()
                  + '-' + ProductID.ToString();
    }
}

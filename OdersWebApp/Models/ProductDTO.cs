using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }  
        public double Price { get; set; }
        public string Description { get; set; }

        public void Load(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            Price = product.UnitPrice;
            Description = product.Description;
        }

    }
}

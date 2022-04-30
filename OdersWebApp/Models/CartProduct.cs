using Newtonsoft.Json;

namespace OdersWebApp.Models
{
    public class CartProduct
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double Subtotal => Product.Price * Quantity;
    }
}

using System.Linq;
using System.Collections.Generic;

namespace OdersWebApp.Models
{
    public static class CartProductListExtension
    {
        public static List<CartProductDTO> ToDTO(this List<CartProduct> list) =>
            list.Select(p => new CartProductDTO
            {
                ProductID = p.Product.ProductID,
                Quantity = p.Quantity
            }).ToList();
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace OdersWebApp.Models
{
    public class Cart
    {
        private const string CartKey = "mycart";
        private const string CountKey = "mycount";
        private OrderContext context { get; set; }

        private List<OrderedProduct> items { get; set; }
        private List<ProductDTO> storedProducts { get; set; }
        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public Cart(HttpContext ctx, OrderContext pctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
            context = pctx;
        }
        public OrderedProduct GetById(int id) =>
            items.FirstOrDefault(p => p.ProductID == id);
        public void Add(OrderedProduct product)
        {
            var productInCart = GetById(product.ProductID);
            // add if new
            if (productInCart == null)
            {
                items.Add(product);
            }
            else // if not new increase quantity by 1
            {
                productInCart.Quantity += 1;
            }
        }
        public void Fill(ProductDTO products)
        {
            items = session.GetObject<List<OrderedProduct>>(CartKey);
            if(items == null)
            {
                items = new List<OrderedProduct>();
                storedProducts = requestCookies.GetObject<List<ProductDTO>>(CartKey);
            }
            if (storedProducts?.Count > items?.Count)
            {
                foreach(ProductDTO storedProduct in storedProducts)
                {
                    var product = context.Products.
                        FirstOrDefault(p => p.ProductID == storedProduct.ProductID);

                }
            }
        }
    }
}

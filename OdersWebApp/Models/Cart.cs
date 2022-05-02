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

        private List<CartProduct> products { get; set; }
        private List<CartProductDTO> storedProducts { get; set; }
        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }
        public double Subtotal => products.Sum(p => p.Subtotal);

        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);

        public IEnumerable<CartProduct> List => products;

        public CartProduct GetById(int id) =>
            products.FirstOrDefault(p => p.Product.ProductID == id);
       
        public void Add(CartProduct product)
        {
            var productInCart = GetById(product.Product.ProductID);
            // add if new
            if (productInCart == null)
            {
                products.Add(product);
            }
            else // if not new increase quantity by 1
            {
                productInCart.Quantity += 1;
            }
        }
        public void Edit(CartProduct product)
        {
            var productInCart = GetById(product.Product.ProductID);
            if (productInCart != null)
            {
                productInCart.Quantity = product.Quantity;
            }
        }
        public void Remove(CartProduct product) => products.Remove(product);

        public void Clear() => products.Clear();

        public void Save()
        {
            if (products.Count == 0)
            {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObject<List<CartProduct>>(CartKey, products);
                session.SetInt32(CountKey, products.Count);
                responseCookies.SetObject<List<CartProductDTO>>(CartKey, products.ToDTO());
                responseCookies.SetInt32(CountKey, products.Count);
            }
        }
        // might have to make the argument a id from a product
        public void Fill(Repo<Product> pData)
        {
            products = session.GetObject<List<CartProduct>>(CartKey);

            if (products == null)
            {
                products = new List<CartProduct>();
                storedProducts = requestCookies.GetObject<List<CartProductDTO>>(CartKey);
            }

            if (storedProducts?.Count > products?.Count)
            {
                foreach (CartProductDTO storedProduct in storedProducts)
                {
                    var product = pData.Get(new QueryOptions<Product>
                    {
                        Where = p => p.ProductID == storedProduct.ProductID
                    });

                    if (product != null)
                    {
                        var pdto = new ProductDTO();
                        pdto.Load(product);

                        CartProduct cProduct = new CartProduct
                        {
                            Product = pdto,
                            Quantity = storedProduct.Quantity
                        };
                        products.Add(cProduct);
                    }
                }
                Save();
            }
        }
    }
}

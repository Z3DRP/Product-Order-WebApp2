using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OdersWebApp.Models
{
    public class TempUserCookies
    {
        private const string ProductKey = "prodKey";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public TempUserCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public TempUserCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }
        public void SetMyProductIds(List<OrderedProduct> myProducts)
        {
            List<int> ids = myProducts.Select(p => p.ProductID).ToList();
            string idString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Today.AddHours(3) };
            RemoveMyProductIds();
            responseCookies.Append(ProductKey, idString, options);
        }
        public string[] GetMyProductIds()
        {
            string cookie = requestCookies[ProductKey];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { }; // empty string array
            else
                return cookie.Split(Delimiter);
        }
        public void RemoveMyProductIds()
        {
            responseCookies.Delete(ProductKey);
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OdersWebApp.Models
{
    public class TempUserSession
    {
        private const string ProductKey = "myProducts";
        private const string CountKey = "productCount";
        private const string NameKey = "usrname";
        private const string TotalKey = "tKey";
        private ISession session { get; set; }
        public TempUserSession(ISession sesh)
        {
            this.session = sesh;
        }
        public void SetMyProducts(List<OrderedProduct> products)
        {
            session.SetObject(ProductKey, products);
            session.SetInt32(CountKey, products.Count);
            SetMyTotal();
        }
        public List<OrderedProduct> GetMyProducts() =>
            // if ProductKey for list not found is session gets empty list
            session.GetObject<List<OrderedProduct>>(ProductKey) ?? new List<OrderedProduct>();
        public int? GetMyProductCount() => 
            session.GetInt32(CountKey);
        public void SetUserName(string usrName)
            => session.SetString(NameKey, usrName);
        public string GetUsrName() => session.GetString(NameKey);
        public void SetMyTotal()
        {
            double total;
            OrderProductListViewModel myProducts = new OrderProductListViewModel();
            myProducts.Products = GetMyProducts();
            total = myProducts.GetOrderTotal();
            session.SetObject(TotalKey, total);
        }
        public string GetMyTotal() => 
            session.GetString(TotalKey);
        public void RemoveMyProducts()
        {
            session.Remove(ProductKey);
            session.Remove(CountKey);
        }
    }
}

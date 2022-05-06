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
        private const string FnameKey = "fName";
        private const string LnameKey = "lname";
        private const string CID = "Cid";

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
        public void SetFname(string fname)
            => session.SetString(FnameKey, fname);
        public string GetFname() => session.GetString(FnameKey);
        public void SetLname(string lname)
            => session.SetString(LnameKey, lname);
        public string GetLname() => session.GetString(LnameKey);
        public void SetCid(string cid)
            => session.SetString(CID, cid);
        public string GetCid() => session.GetString(CID);
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
        public void RemoveCustomerID()
            => session.Remove(CID);
        public void RemoveFname()
            => session.Remove(FnameKey);
        public void RemoveLname()
            => session.Remove(LnameKey);
    }
}

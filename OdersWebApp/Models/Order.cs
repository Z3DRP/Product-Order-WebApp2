using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdersWebApp.Models
{
    public class Order
    {
        const double SalesTax = .11;
        public DateTime dDate;
        public double oPrice;

        public int OrderID { get; set; }

        [Required(ErrorMessage = "Enter a Customer Id")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Enter a Product Id")]
        public int ProductID { get; set; }
        public ICollection<OrderedProduct> Product { get; set; }

        //[Required(ErrorMessage = "Enter a order date")]
        [DataType(DataType.Date, ErrorMessage = "Delivery date must be in date format")]
        public DateTime OrderDate { get; set; }

        //[Required(ErrorMessage = "Enter a delivery date")]
        [DataType(DataType.DateTime, ErrorMessage = "Delivery date must be in date format")]
        public DateTime DeliveryDate
        {
            get => dDate;
            set
            {
                dDate = OrderDate.AddDays(7);
            }
        }

        //[Required(ErrorMessage = "Enter a order price")]
        public double OrderPrice
        {
            get => oPrice;
            set => oPrice = CalculateOrder();
        }
        public double CalculateOrder()
        {
            double orderPrice = 0;
            double tax = orderPrice * SalesTax;

            if (Product.Count > 0)
                foreach (OrderedProduct p in Product)
                {
                    orderPrice += p.CalculateProductPrice();
                }

            return orderPrice + tax;
        }
        public string Slug => CustomerID.ToString() + "-" + OrderDate.ToShortDateString();

    }
}

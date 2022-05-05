using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class CustomerSignUpViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Username { get; set; }
        public string Slug => FirstName?.Replace(' ', '-').ToLower()
   + '-' + LastName?.Replace(' ', '-').ToLower();

        public string CustomerFullName => FirstName + " " + LastName;
    }
}

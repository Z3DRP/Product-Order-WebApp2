using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdersWebApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Enter a first name")]
        [MaxLength(35, ErrorMessage = "First name must be 35 characters or less")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name")]
        [MaxLength(35, ErrorMessage = "Last name must be 35 characters or less")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter a phone number")]
        [MaxLength(12, ErrorMessage = "Phone number must be in 000-000-0000 format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You must enter a email address")]
        [MaxLength(50, ErrorMessage = "Email must be 50 characters or less")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You must enter a street")]
        [MaxLength(75, ErrorMessage = "Street must be 75 characters or less")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Enter a city")]
        [MaxLength(75, ErrorMessage = "City must be 75 characters or less")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter a state")]
        [MaxLength(75, ErrorMessage = "State must be 75 characters or less")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter a zipcode")]
        [MaxLength(5, ErrorMessage = "Zipcode must be 5 chacters")]
        public string Zipcode { get; set; }

        public string Slug => FirstName?.Replace(' ', '-').ToLower()
    + '-' + LastName?.Replace(' ', '-').ToLower();

        public string CustomerFullName => FirstName + " " + LastName;

        //[Required(ErrorMessage = "Enter a order id")]
        //public int OrderID { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}

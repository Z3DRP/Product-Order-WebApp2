using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdersWebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(70,ErrorMessage = "Name must be 70 characters or less")]
        public int UserID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [MaxLength(25,ErrorMessage = "Username must be 25 characters or less")]
        public string Username { get; set; }
        [Required]
        [MaxLength(65,ErrorMessage = "Password must be 25 characters or less")]
        public string Password { get; set; }
    }
}

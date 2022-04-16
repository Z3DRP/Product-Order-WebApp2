using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdersWebApp.Models
{
    public class TempUser
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Username must be 25 characters or less")]
        public string Username { get; set; }
    }
}

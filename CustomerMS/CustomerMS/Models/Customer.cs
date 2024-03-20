using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } = 0;
        public string Name { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string ContactNo { get; set; }
        public string Locality { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public string EmailId { get; set; }

        public string Requirement { get; set; }
    }
}

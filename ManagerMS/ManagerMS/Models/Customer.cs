using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMS.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } = 0;
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string ContactNo { get; set; }
        public string Locality { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [ForeignKey("RequirementId")]
        public int RequirementId { get; set; }

        [Required]
        public string ExecutiveAssigned { get; set; }
    }
}

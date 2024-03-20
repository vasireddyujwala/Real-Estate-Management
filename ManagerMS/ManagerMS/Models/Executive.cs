using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMS.Models
{
    public class Executive
    {
        [Key]

        public int ExecutiveId { get; set; } = 0;

        [Required(ErrorMessage = "Executive name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string ContactNo { get; set; }
        public string Locality { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string EmailId { get; set; }
    }
}

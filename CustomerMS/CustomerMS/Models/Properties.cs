using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Models
{
    public class Properties
    {
        [Key]
        public int RequirementId { get; set; }
        public string PropertyType { get; set; }
        public int Budget { get; set; }
        public string Locality { get; set; }
    }
}

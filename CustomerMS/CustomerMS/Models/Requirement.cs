using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Models
{
    public class Requirement
    {
        [Key]
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public int Budget { get; set; }
        public string Locality { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMS.Models
{
    public class Properties
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public int Budget { get; set; }
        public string Locality { get; set; }
    }
}

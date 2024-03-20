using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMS.Models
{
    public class CustomerExecutiveModel
    {

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ExecutiveId { get; set; }
    }
}

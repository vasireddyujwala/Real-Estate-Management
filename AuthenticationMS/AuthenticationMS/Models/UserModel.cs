using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationMS.Models
{
    public class UserModel
    {
        [Key]
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}

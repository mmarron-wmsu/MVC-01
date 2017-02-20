using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dudungcharing.Areas.security.Models
{
    public class UserModel
    {
        public Guid id{ get; set;}
        public String Firstname { get; set;}
        public String Lastname { get; set;}
        public int? Age { get; set; }
        
    }
}
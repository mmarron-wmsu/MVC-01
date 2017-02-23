using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuksanDemo.Areas.Security.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Minimum of 4 Letters only!")]
        [MaxLength(10, ErrorMessage = "Maximum of 10 Letters only!")]
        public String FirstName { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Minimum of 4 Letters only!")]
        [MaxLength(10, ErrorMessage = "Maximum of 10 Letters only!")]
        public String LastName { get; set; }

        public String Gender { get; set; }

       
        public int? Age { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuksanDemo.Dal
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? EmploymentDate { get; set; }
    }
}

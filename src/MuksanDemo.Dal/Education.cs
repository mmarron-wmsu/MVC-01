﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mydudungcharing.dal
{
    public class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string School { get; set; }
        public string YearAttended { get; set; }

        public User User { get; set; }
    }
}


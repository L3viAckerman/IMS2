using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public Admin Admin { get; set; }
        public HrEmployee HrEmployee { get; set; }
        public Lecture Lecture { get; set; }
        public Student Student { get; set; }
    }
}

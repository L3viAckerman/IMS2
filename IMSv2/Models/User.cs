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

        public Hremployee Id1 { get; set; }
        public Lecture Id2 { get; set; }
        public Student Id3 { get; set; }
        public Admin IdNavigation { get; set; }
    }
}

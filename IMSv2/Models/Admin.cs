using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Organization { get; set; }
        public string Vnumail { get; set; }
        public string Phone { get; set; }

        public User IdNavigation { get; set; }
    }
}

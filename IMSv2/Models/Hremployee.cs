using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Hremployee
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public Company Company { get; set; }
        public User User { get; set; }
    }
}

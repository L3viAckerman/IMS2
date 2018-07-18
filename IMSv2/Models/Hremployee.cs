using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class HrEmployee
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string Display { get; set; }
        public long Cx { get; set; }
        public string Name { get; set; }

        public Company Company { get; set; }
        public User IdNavigation { get; set; }
    }
}

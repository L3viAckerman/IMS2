using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Company
    {
        public Company()
        {
            HrEmployee = new HashSet<HrEmployee>();
            InternNews = new HashSet<InternNews>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<HrEmployee> HrEmployee { get; set; }
        public ICollection<InternNews> InternNews { get; set; }
    }
}

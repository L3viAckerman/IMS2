using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Company
    {
        public Company()
        {
            Hremployee = new HashSet<Hremployee>();
            InternNews = new HashSet<InternNews>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Hremployee> Hremployee { get; set; }
        public ICollection<InternNews> InternNews { get; set; }
    }
}

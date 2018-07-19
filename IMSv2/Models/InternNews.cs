using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class InternNews
    {
        public InternNews()
        {
            InternFollow = new HashSet<InternFollow>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public Company Company { get; set; }
        public ICollection<InternFollow> InternFollow { get; set; }
    }
}

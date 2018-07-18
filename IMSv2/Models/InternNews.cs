using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class InternNews
    {
        public InternNews()
        {
            InternFollows = new HashSet<InternFollow>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public long Cx { get; set; }

        public Company Company { get; set; }
        public ICollection<InternFollow> InternFollows { get; set; }
    }
}

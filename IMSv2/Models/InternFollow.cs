using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class InternFollow
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid InternNewsId { get; set; }
        public int Status { get; set; }
        public long Cx { get; set; }

        public InternNews InternNews { get; set; }
        public Student Student { get; set; }
    }
}

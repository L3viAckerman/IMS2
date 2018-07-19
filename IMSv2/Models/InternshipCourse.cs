using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class InternshipCourse
    {
        public InternshipCourse()
        {
            InternReport = new HashSet<InternReport>();
        }

        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string File { get; set; }
        public string LectureComment { get; set; }
        public string CompanyComment { get; set; }

        public Student Student { get; set; }
        public ICollection<InternReport> InternReport { get; set; }
    }
}

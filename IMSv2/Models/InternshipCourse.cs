using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class InternshipCourse
    {
        public InternshipCourse()
        {
            InternReports = new HashSet<InternReport>();
        }

        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string File { get; set; }
        public string LecturerComment { get; set; }
        public string CompanyComment { get; set; }
        public long Cx { get; set; }
        public Guid? LecturerId { get; set; }
        public int? FinalScore { get; set; }

        public Company Company { get; set; }
        public Lecturer Lecturer { get; set; }
        public Student Student { get; set; }
        public ICollection<InternReport> InternReports { get; set; }
    }
}

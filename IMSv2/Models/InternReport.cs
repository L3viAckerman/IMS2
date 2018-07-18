using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class InternReport
    {
        public Guid Id { get; set; }
        public Guid? InternshipCourseId { get; set; }
        public string Content { get; set; }
        public double PartnerScore { get; set; }
        public double LecturerScore { get; set; }
        public DateTime Date { get; set; }
        public string LecturerComment { get; set; }
        public string CompanyComment { get; set; }
        public long Cx { get; set; }

        public InternshipCourse InternshipCourse { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class InternReport
    {
        public Guid Id { get; set; }
        public Guid? InternshipCourseId { get; set; }
        public string Content { get; set; }
        public double? PartnerScore { get; set; }
        public double? LectureScore { get; set; }
        public DateTime? Date { get; set; }
        public string LectureComment { get; set; }
        public string CompanyComment { get; set; }

        public InternshipCourse InternshipCourse { get; set; }
    }
}

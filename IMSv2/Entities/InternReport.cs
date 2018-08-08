using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class InternReportEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? InternshipCourseId { get; set; }
        public string Content { get; set; }
        public double? PartnerScore { get; set; }
        public double? LectureScore { get; set; }
        public DateTime? Date { get; set; }
        public string LectureComment { get; set; }
        public string CompanyComment { get; set; }

        public InternshipCourseEntity InternshipCourseEntity { get; set; }

        public InternReportEntity() : base() { }

        public InternReportEntity(InternReport InternReport, params object[] args) : base(InternReport)
        {
            foreach(object arg in args)
            {
                if (arg is InternshipCourse internshipCourse) InternshipCourseEntity = new InternshipCourseEntity(internshipCourse);
            }
        } 
    }
}

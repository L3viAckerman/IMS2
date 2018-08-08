using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSv2.Entities
{
    public partial class InternshipCourseEntity : BaseEntity
    {
       

        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string File { get; set; }
        public string LectureComment { get; set; }
        public string CompanyComment { get; set; }

        public StudentEntity StudentEntity { get; set; }
        public List<InternReportEntity> InternReportEntities { get; set; }

        public InternshipCourseEntity() : base() { }

        public InternshipCourseEntity(InternshipCourse internshipCourse, params object[] args) : base(internshipCourse)
        {
            foreach(object arg in args)
            {
                if (arg is Student Student) StudentEntity = new StudentEntity(Student);
                if (arg is ICollection<InternReport> InternReport) InternReportEntities = InternReport.Select(m => new InternReportEntity(m)).ToList();
            }
        }
    }
}

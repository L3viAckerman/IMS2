using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Company
    {
        public Company()
        {
            HrEmployees = new HashSet<HrEmployee>();
            InternNews = new HashSet<InternNews>();
            InternshipCourses = new HashSet<InternshipCourse>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Cx { get; set; }
        public string Address { get; set; }

        public ICollection<HrEmployee> HrEmployees { get; set; }
        public ICollection<InternNews> InternNews { get; set; }
        public ICollection<InternshipCourse> InternshipCourses { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            InternshipCourses = new HashSet<InternshipCourse>();
            LecturerFollows = new HashSet<LecturerFollow>();
            StudentLecturers = new HashSet<StudentLecturer>();
        }

        public Guid Id { get; set; }
        public string Vnumail { get; set; }
        public string Gmail { get; set; }
        public string Note { get; set; }
        public long Cx { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public User IdNavigation { get; set; }
        public ICollection<InternshipCourse> InternshipCourses { get; set; }
        public ICollection<LecturerFollow> LecturerFollows { get; set; }
        public ICollection<StudentLecturer> StudentLecturers { get; set; }
    }
}

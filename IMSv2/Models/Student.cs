using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Student
    {
        public Student()
        {
            InternFollow = new HashSet<InternFollow>();
            InternshipCourse = new HashSet<InternshipCourse>();
            LectureFollow = new HashSet<LectureFollow>();
            StudentLecture = new HashSet<StudentLecture>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Class { get; set; }
        public string AcademicYear { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Vnumail { get; set; }
        public double? Gpa { get; set; }
        public string GraduationYear { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string LanguageSkill { get; set; }
        public string Certificate { get; set; }
        public string Goal { get; set; }
        public string Experience { get; set; }
        public string Note { get; set; }
        public string Hobbie { get; set; }

        public User IdNavigation { get; set; }
        public ICollection<InternFollow> InternFollow { get; set; }
        public ICollection<InternshipCourse> InternshipCourse { get; set; }
        public ICollection<LectureFollow> LectureFollow { get; set; }
        public ICollection<StudentLecture> StudentLecture { get; set; }
    }
}

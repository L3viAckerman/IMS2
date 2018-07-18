using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Student
    {
        public Student()
        {
            InternFollows = new HashSet<InternFollow>();
            InternshipCourses = new HashSet<InternshipCourse>();
            LecturerFollows = new HashSet<LecturerFollow>();
            StudentLecturers = new HashSet<StudentLecturer>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Class { get; set; }
        public string AcademicYear { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Vnumail { get; set; }
        public string Gpa { get; set; }
        public string GraduationYear { get; set; }
        public string Avatar { get; set; }
        public string PersonalMail { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string LanguageSkill { get; set; }
        public string Certificate { get; set; }
        public string Experience { get; set; }
        public string Goal { get; set; }
        public string Note { get; set; }
        public long Cx { get; set; }

        public User IdNavigation { get; set; }
        public ICollection<InternFollow> InternFollows { get; set; }
        public ICollection<InternshipCourse> InternshipCourses { get; set; }
        public ICollection<LecturerFollow> LecturerFollows { get; set; }
        public ICollection<StudentLecturer> StudentLecturers { get; set; }
    }
}

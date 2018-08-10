using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSv2.Entities
{
    public partial class StudentEntity : BaseEntity 
    {
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

        public List<InternFollowEntity> InternFollowEntities { get; set; }
        public List<InternshipCourseEntity> InternshipCourseEntities { get; set; }
        public List<LectureFollowEntity> LectureFollowEntities { get; set; }
        public List<StudentLectureEntity> StudentLectureEntities { get; set; }

        public StudentEntity() : base() { }

        public StudentEntity(Student student, params object[] args) : base(student)
        {
            foreach(object arg in args)
            {
                if (arg is ICollection<InternFollow> InternFollow) InternFollowEntities = InternFollow.Select(m => new InternFollowEntity(m)).ToList();
                if (arg is ICollection<InternshipCourse> InternshipCourse) InternshipCourseEntities = InternshipCourse.Select(m => new InternshipCourseEntity(m)).ToList();
                if (arg is ICollection<LectureFollow> LectureFollow) LectureFollowEntities = LectureFollow.Select(m => new LectureFollowEntity(m)).ToList();
                if (arg is ICollection<StudentLecture> StudentLecture) StudentLectureEntities = StudentLecture.Select(m => new StudentLectureEntity(m)).ToList();
            }
        }
    }

    public class SearchStudentEntity : FilterEntity
    {
        public string Fullname { get;  }
        public string Vnumail { get;  }
    }
}

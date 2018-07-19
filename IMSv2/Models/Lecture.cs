using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            LectureFollow = new HashSet<LectureFollow>();
            StudentLecture = new HashSet<StudentLecture>();
        }

        public Guid Id { get; set; }
        public string Vnumail { get; set; }
        public string Gmail { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public User User { get; set; }
        public ICollection<LectureFollow> LectureFollow { get; set; }
        public ICollection<StudentLecture> StudentLecture { get; set; }
    }
}

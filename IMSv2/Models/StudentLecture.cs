using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class StudentLecture
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? LectureId { get; set; }

        public Lecture Lecture { get; set; }
        public Student Student { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class StudentLecturer
    {
        public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Student Student { get; set; }
    }
}

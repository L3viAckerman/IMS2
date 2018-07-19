using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class LectureFollow
    {
        public Guid Id { get; set; }
        public Guid? StudentIid { get; set; }
        public Guid? LectureId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public Lecture Lecture { get; set; }
        public Student StudentI { get; set; }
    }
}

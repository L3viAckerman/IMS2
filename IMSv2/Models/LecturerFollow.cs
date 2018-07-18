using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class LecturerFollow
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }
        public int Status { get; set; }
        public long Cx { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Lecturer Lecturer { get; set; }
        public Student Student { get; set; }
    }
}

using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class StudentLectureEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? LectureId { get; set; }

        public LectureEntity LectureEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }

        public StudentLectureEntity() : base() { }

        public StudentLectureEntity(StudentLecture studentLecture) : base(studentLecture)
        {

        }
    }
}

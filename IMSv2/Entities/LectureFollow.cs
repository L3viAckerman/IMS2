using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class LectureFollowEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? StudentIid { get; set; }
        public Guid? LectureId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public LectureEntity LectureEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }

        public LectureFollowEntity() : base() { }

        public LectureFollowEntity(LectureFollow lectureFollow, params object[] args) : base(lectureFollow)
        {
            foreach(object arg in args)
            {
                if (arg is Lecture Lecture) LectureEntity = new LectureEntity(Lecture);
                if (arg is Student Student) StudentEntity = new StudentEntity(Student);
            }
        }
    }
}

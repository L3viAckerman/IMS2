using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSv2.Entities
{
    public partial class LectureEntity : BaseEntity
    {
       

        public Guid Id { get; set; }
        public string Vnumail { get; set; }
        public string Gmail { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

      
        public List<LectureFollowEntity> LectureFollowEntities { get; set; }
        public List<StudentLectureEntity> StudentLectureEntities { get; set; }

        public LectureEntity() : base()
        {

        }

        public LectureEntity(Lecture Lecture, params object[] args) : base(Lecture)
        {
            foreach(object arg in args)
            {
                if (arg is ICollection<LectureFollow> LectureFollow) LectureFollowEntities = LectureFollow.Select(m => new LectureFollowEntity(m)).ToList();
                if (arg is ICollection<StudentLecture> StudentLecture) StudentLectureEntities = StudentLecture.Select(m => new StudentLectureEntity(m)).ToList();
            }
        }
    }
}

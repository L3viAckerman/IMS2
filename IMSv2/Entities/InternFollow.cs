using IMSv2.Entities;
using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class InternFollowEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? InternNewsId { get; set; }
        public int? Status { get; set; }

        public InternNewsEntity InternNewsEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }

        public InternFollowEntity() : base() { }

        public InternFollowEntity(InternFollow internFollow, params object[] args) : base(internFollow)
        {
            foreach(object arg in args)
            {
                if (arg is InternNews internNews) InternNewsEntity = new InternNewsEntity(internNews);
                if (arg is Student student) StudentEntity = new StudentEntity(student);
            }
        }
    }
}

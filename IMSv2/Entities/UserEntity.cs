using IMSv2.Entities;
using IMSv2.IMSCommon;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public AdminEntity AdminEntity { get; set; }
        public HrEmployeeEntity HrEmployeeEntity { get; set; }
        public LectureEntity LectureEntity { get; set; }
        public StudentEntity StudentEntity { get; set; }

        public UserEntity() : base() { }
    }
}

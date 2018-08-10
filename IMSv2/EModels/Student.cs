using IMSv2.Entities;
using IMSv2.IMSCommon;
using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Student : Base
    {
        public override bool Equals(Base other)
        {
            throw new NotImplementedException();
        }
        public Student(StudentEntity StudentEntity) : base(StudentEntity)
        {

        }
    }

}

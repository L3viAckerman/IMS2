using IMSv2.Entities;
using IMSv2.IMSCommon;
using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class HrEmployee : Base
    {
        public override bool Equals(Base other)
        {
            throw new NotImplementedException();
        }
        public HrEmployee(HrEmployeeEntity HrEmployeeEntity) : base(HrEmployeeEntity)
        {

        }
    }
}

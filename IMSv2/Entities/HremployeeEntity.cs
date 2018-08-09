using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class HrEmployeeEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public HrEmployeeEntity() : base() { }

        public HrEmployeeEntity(HrEmployee hrEmployee) : base(hrEmployee)
        {

        }
    }
    public class SearchHrEmployeeEntity : FilterEntity
    {
        public Guid? CompanyId { get;  }
        public string Phone { get;  }
    }
}

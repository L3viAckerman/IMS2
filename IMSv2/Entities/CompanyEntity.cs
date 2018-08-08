using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSv2.Entities
{
    public partial class CompanyEntity: BaseEntity
    {
        

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<HrEmployeeEntity> HrEmployeeEntities { get; set; }
        public List<InternNewsEntity> InternNewsEntities { get; set; }

        public CompanyEntity() : base() { }

        public CompanyEntity(Company company, params object[] args) : base(company)
        {
            foreach(object arg in args)
            {
                if (arg is ICollection<HrEmployee> Hremployees) HrEmployeeEntities = Hremployees.Select(models => new HrEmployeeEntity(models)).ToList();
                if (arg is ICollection<InternNews> InternNews) InternNewsEntities = InternNews.Select(m => new InternNewsEntity(m)).ToList();
            }
        }
    }
}

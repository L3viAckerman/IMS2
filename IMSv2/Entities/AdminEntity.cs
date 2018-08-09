using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Entities
{
    public class AdminEntity : BaseEntity 
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Organization { get; set; }
        public string Vnumail { get; set; }
        public string Phone { get; set; }

        public AdminEntity() : base() { }

        public AdminEntity(Admin admin) : base(admin)
        {
           
        }
    }
    public class AdminSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Vnumail { get; set; }
    }
}

using IMSv2.IMSCommon;
using IMSv2.Modules;
using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Method { get; set; }
        public ROLES Role { get; set; }
    }
}

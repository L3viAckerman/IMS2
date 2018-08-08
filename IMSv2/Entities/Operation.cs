using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class OperationEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Method { get; set; }

        public OperationEntity() : base() { }

        public OperationEntity(Operation operation) : base(operation) { }
    }
}

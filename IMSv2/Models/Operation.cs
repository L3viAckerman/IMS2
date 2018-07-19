using System;
using System.Collections.Generic;

namespace IMSv2.Models
{
    public partial class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Method { get; set; }
    }
}

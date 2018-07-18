using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public partial class Message
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public long Cx { get; set; }
    }
}

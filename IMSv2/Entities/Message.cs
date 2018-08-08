using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;

namespace IMSv2.Entities
{
    public partial class MessageEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? Sender { get; set; }
        public Guid? Receiver { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public DateTime? Date { get; set; }

        public MessageEntity() : base() { }

        public MessageEntity(Message message) : base(message) { }
    }
}

using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSv2.Entities
{
    public partial class InternNewsEntity : BaseEntity
    {
        

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public CompanyEntity CompanyEntity { get; set; }
        public List<InternFollowEntity> InternFollowEntities { get; set; }

        public InternNewsEntity() : base() { }

        public InternNewsEntity(InternNews internNews, params object[] args) : base(internNews)
        {
            foreach(object arg in args)
            {
                if (arg is Company company) CompanyEntity = new CompanyEntity(company);
                if (arg is ICollection<InternFollow> InternFollow) InternFollowEntities = InternFollow.Select(m => new InternFollowEntity(m)).ToList();
            }
        }
    }
}

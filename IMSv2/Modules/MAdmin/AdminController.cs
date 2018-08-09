using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSv2.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSv2.Modules.MAdmin
{
    [Route("api/Admin")]
    public class AdminController : CommonController
    {
        private IAdminService AdminService;
        public AdminController(IAdminService AdminService)
        {
            this.AdminService = AdminService;
        }

        [Route(""), HttpGet]
        public List<AdminEntity> Get(AdminSearchEntity AdminSearchEntity)
        {
            return AdminService.Get(UserEntity, AdminSearchEntity);
        }

        [Route("Count"), HttpGet]
        public int Count(AdminSearchEntity AdminSearchEntity)
        {
            return AdminService.Count(UserEntity, AdminSearchEntity);
        }

        [Route("{AdminId}"), HttpGet]

        public AdminEntity Get(Guid AdminId)
        {
            return AdminService.Get(UserEntity, AdminId);
        }

        [Route("{AdminId}"), HttpPut]
        public AdminEntity Update(Guid AdminId,[FromBody] AdminEntity AdminEntity)
        {
            return AdminService.Update(UserEntity, AdminId, AdminEntity);
        }
        [Route(""),HttpPost]
        public AdminEntity Create([FromBody] AdminEntity AdminEntity)
        {
            return AdminService.Create(UserEntity, AdminEntity);
        }
        [Route("{AdminId}"),HttpDelete]
        public bool Delete(Guid AdminId)
        {
            return AdminService.Delete(UserEntity, AdminId);
        }
    }
     
}

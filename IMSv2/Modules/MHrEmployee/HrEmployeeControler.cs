using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSv2.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSv2.Modules.MHrEmployee
{
    [Route("api/HrEmployee")]
    public class HrEmployeeControler : CommonController
    {
        private IHrEmployeeSevice HrEmployeeService;

        public HrEmployeeControler(IHrEmployeeSevice HrEployeeService)
        {
            this.HrEmployeeService = HrEmployeeService;
        }
        [Route(""), HttpGet]
        public List<HrEmployeeEntity> Get(SearchHrEmployeeEntity searchHrEmployeeEntity)
        {
            return HrEmployeeService.Get(UserEntity, searchHrEmployeeEntity);
        }
        [Route("{HrEmployeeId}"), HttpGet]
        public HrEmployeeEntity Get(Guid HrEmployeeId)
        {
            return HrEmployeeService.Get(UserEntity, HrEmployeeId);
        }
        [Route("Count"), HttpGet]
        public int Count(SearchHrEmployeeEntity searchHrEmployeeEntity)
        {
            return HrEmployeeService.Count(UserEntity, searchHrEmployeeEntity);
        }
        [Route(""), HttpPost]
        public HrEmployeeEntity Create([FromBody]HrEmployeeEntity hrEmployeeEntity)
        {
            return HrEmployeeService.Create(UserEntity, hrEmployeeEntity);
        }

        [Route("HrEmployeeId"), HttpPut]
        public HrEmployeeEntity Update(Guid HrEmployeeId, [FromBody] HrEmployeeEntity hrEmployeeEntity)
        {
            return HrEmployeeService.Update(UserEntity, HrEmployeeId, hrEmployeeEntity);
        }

        [Route("HrEmployeeId"), HttpDelete]
        public bool Delete(Guid HrEmployeeId)
        {
            return HrEmployeeService.Delete(UserEntity, HrEmployeeId);
        }
    }
}

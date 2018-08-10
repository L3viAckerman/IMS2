using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSv2.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSv2.Modules.MStudent
{
    [Route("api/Student")]
    public class StudentController : CommonController
    {
        private IStudentService StudentService;
        public StudentController(IStudentService studentService) 
        {
            StudentService = studentService;
        }

        [Route("Count"), HttpGet]
        public int Count(UserEntity UserEntity, SearchStudentEntity searchStudentEntity)
        {
            return StudentService.Count(UserEntity, searchStudentEntity);
        }
}

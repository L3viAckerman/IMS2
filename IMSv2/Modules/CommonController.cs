using IMSv2.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IMSv2.Modules
{
    public class CommonController : Controller
    {
        public UserEntity UserEntity => (User as MyPrincipal)?.UserEntity;
    }
}

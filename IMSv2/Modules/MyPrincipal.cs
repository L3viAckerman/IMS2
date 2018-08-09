using IMSv2.Entities;
using System.Security.Claims;

namespace IMSv2.Modules
{
    internal class MyPrincipal : ClaimsPrincipal
    {
        public UserEntity UserEntity { get;  }

        public MyPrincipal(UserEntity UserEntity = null)
        {
            this.UserEntity = UserEntity;
        }
    }
}
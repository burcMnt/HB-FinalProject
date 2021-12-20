using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.IdentityJwt
{
    public interface IUserService
    {
        UserToken Authenticate(string email, string passwrd);
    }

   
}

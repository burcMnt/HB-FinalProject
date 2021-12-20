using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.IdentityJwt
{
    public class UserService : IUserService
    {
        private readonly List<UserToken> _user;
        public UserService()
        {
            _user = new List<UserToken>
            {
                new UserToken
                {
                Id = 1,
                Email = "girismail@exp.com",
                Password = "ankara1."
                }

            };
        }
        public UserToken Authenticate(string email, string passwrd)
        {
            return _user.FirstOrDefault(x => x.Email == email && x.Password == passwrd);
        }
    }
}

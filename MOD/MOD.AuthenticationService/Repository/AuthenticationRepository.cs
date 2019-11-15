using MOD.AuthenticationService.DBContexts;
using MOD.AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthenticationService.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationContext authenticationContext;

        public AuthenticationRepository
            (AuthenticationContext _authenticationContext)
        {
            authenticationContext = _authenticationContext;
        }

        public bool AuthenticateAdmin(Admin admin)
        {
            var adminItem = authenticationContext.Admins
                .Where(x => x.userName
                .Equals(admin.userName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if(adminItem != null && adminItem.password.Equals(admin.password))
            {
                return true;
            }
            return false;
        }

        public bool AuthenticateMentor(Mentor mentor)
        {
            var mentorItem = authenticationContext.Mentors
                .Where(x => x.userName
                .Equals(mentor.userName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (mentorItem != null && mentorItem.password.Equals(mentor.password))
            {
                return true;
            }
            return false;
        }

        public bool AuthenticateUser(User user)
        {
            var userItem = authenticationContext.Users
                .Where(x => x.userName
                .Equals(user.userName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (userItem != null && userItem.password.Equals(user.password))
            {
                return true;
            }
            return false;
        }
    }
}

using MOD.AuthenticationService.Models;

namespace MOD.AuthenticationService.Repository
{
    public interface IAuthenticationRepository
    {
        bool AuthenticateUser(User user);
        bool AuthenticateMentor(Mentor mentor);
        bool AuthenticateAdmin(Admin admin);
    }
}

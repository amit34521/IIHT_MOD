using MOD.UserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.UserService.Repository
{
    public interface IUsersRepository
    {
        List<User> GetUsers();
        void AddUsers(User user);
        void UpdateUsers(User user);
        void DeleteUsers(long id);
        User GetUserById(long id);
        bool CheckUserAvailability(string userName);
        List<Mentor> GetMentors();
        void AddMentors(Mentor user);
        void UpdateMentors(Mentor user);
        void DeleteMentors(long id);
        Mentor GetMentorById(long id);
        bool CheckMentorAvailability(string userName);
        void AddAdmin(Admin admin);
    }
}

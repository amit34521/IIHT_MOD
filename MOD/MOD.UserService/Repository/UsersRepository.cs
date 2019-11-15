using System;
using System.Collections.Generic;
using System.Linq;
using MOD.UserService.DBContexts;
using MOD.UserService.Models;

namespace MOD.UserService.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserContext _userContext;

        public UsersRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Save()
        {
            _userContext.SaveChanges();
        }

        public void AddUsers(User user)
        {
            _userContext.Users.Add(user);
            Save();
        }

        public void DeleteUsers(long id)
        {
            var user = _userContext.Users.First(x => x.Id == id);
            _userContext.Users.Remove(user);
            Save();
        }

        public User GetUserById(long id)
        {
            var user = _userContext.Users.Find(id);
            return user;
        }

        public void UpdateUsers(User user)
        {
            bool status = CheckUserAvailability(user.userName);
            if (status)
            {
                var userToUpdate = _userContext.Users
                    .FirstOrDefault(x => x.userName.Equals(user.userName,
                    StringComparison.OrdinalIgnoreCase));
                userToUpdate.firstName = user.firstName;
                userToUpdate.lastName = user.lastName;
                userToUpdate.contactNumber = user.contactNumber;
                Save();
            }
        }

        public List<User> GetUsers()
        {
            return _userContext.Users.ToList();
        }

        public bool CheckUserAvailability(string userName)
        {
            var user = _userContext.Users.FirstOrDefault(x =>
              x.userName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                return false;
            return true;
        }

        public void AddMentors(Mentor user)
        {
            _userContext.Mentors.Add(user);
            Save();
        }

        public void DeleteMentors(long id)
        {
            var user = _userContext.Mentors.First(x => x.Id == id);
            _userContext.Mentors.Remove(user);
            Save();
        }

        public Mentor GetMentorById(long id)
        {
            var user = _userContext.Mentors.Find(id);
            return user;
        }

        public void UpdateMentors(Mentor user)
        {
            bool status = CheckMentorAvailability(user.userName);
            if (status)
            {
                var userToUpdate = _userContext.Mentors
                    .FirstOrDefault(x => x.userName.Equals(user.userName,
                    StringComparison.OrdinalIgnoreCase));
                userToUpdate.firstName = user.firstName;
                userToUpdate.lastName = user.lastName;
                userToUpdate.contactNumber = user.contactNumber;
                Save();
            }
        }

        public List<Mentor> GetMentors()
        {
            return _userContext.Mentors.ToList();
        }

        public bool CheckMentorAvailability(string userName)
        {
            var user = _userContext.Mentors.FirstOrDefault(x =>
              x.userName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                return false;
            return true;
        }

        public void AddAdmin(Admin admin)
        {
            _userContext.Admins.Add(admin);
            Save();
        }
    }
}

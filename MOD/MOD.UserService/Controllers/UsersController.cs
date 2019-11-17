using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.UserService.Models;
using MOD.UserService.Repository;

namespace MOD.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<string> GetAllUsers()
        {
            return Ok(_usersRepository.GetUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id:long:min(1)}")]
        public ActionResult<string> GetUserByName(long id)
        {
            var userDetail = _usersRepository.GetUserById(id);
            if (userDetail == null)
                return NoContent();
            return Ok(userDetail);
        }

        [HttpGet("{name}")]
        public ActionResult<string> CheckUser(string name)
        {
            var result = _usersRepository.CheckUserAvailability(name);
            if (!result)
                return NoContent();
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _usersRepository.AddUsers(user);
        }

        // PUT: api/Users/5
        [HttpPut]
        public void UpdateUser([FromBody] User user)
        {
            _usersRepository.UpdateUsers(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteUser(long id)
        {
            _usersRepository.DeleteUsers(id);
        }

        [Route("/api/Mentors")]
        [HttpGet]
        public ActionResult<string> GetMentors()
        {
            return Ok(_usersRepository.GetMentors());
        }

        [Route("/api/Mentors/{id:long:min(1)}")]
        [HttpGet]
        public ActionResult<string> GetMentorById(long id)
        {
            var userDetail = _usersRepository.GetMentorById(id);
            if (userDetail == null)
                return NoContent();
            return Ok(userDetail);
        }

        [Route("/api/Mentors/{name}")]
        [HttpGet]
        public ActionResult<string> CheckMentors(string name)
        {
            var result = _usersRepository.CheckMentorAvailability(name);
            if (!result)
                return NoContent();
            return Ok(result);
        }

        [Route("api/Mentors")]
        [HttpPost]
        public void AddMentor([FromBody] Mentor mentor)
        {
            _usersRepository.AddMentors(mentor);
        }

        [Route("api/Mentors")]
        [HttpPut]
        public void UpdateMentor([FromBody] Mentor user)
        {
            _usersRepository.UpdateMentors(user);
        }

        [Route("api/Mentors/{id:long:min(1)}")]
        [HttpDelete]
        public void DeleteMentor(long id)
        {
            _usersRepository.DeleteMentors(id);
        }

        [Route("api/Admin")]
        [HttpPost]
        public void AddAdmin([FromBody] Admin admin)
        {
            _usersRepository.AddAdmin(admin);
        }
    }
}

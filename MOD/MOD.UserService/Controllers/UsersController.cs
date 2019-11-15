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

        [HttpGet("Mentors")]
        public ActionResult<string> GetMentors()
        {
            return Ok(_usersRepository.GetMentors());
        }

        // GET: api/Users/5
        [HttpGet("Mentors/{id:long:min(1)}")]
        public ActionResult<string> GetMentorById(long id)
        {
            var userDetail = _usersRepository.GetMentorById(id);
            if (userDetail == null)
                return NoContent();
            return Ok(userDetail);
        }

        [HttpGet("Mentors/{name}")]
        public ActionResult<string> CheckMentors(string name)
        {
            var result = _usersRepository.CheckMentorAvailability(name);
            if (!result)
                return NoContent();
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost("Mentors")]
        public void AddMentor([FromBody] Mentor user)
        {
            _usersRepository.AddMentors(user);
        }

        // PUT: api/Users/5
        [HttpPut("Mentors")]
        public void UpdateMentor([FromBody] Mentor user)
        {
            _usersRepository.UpdateMentors(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Mentors/{id}")]
        public void DeleteMentor(long id)
        {
            _usersRepository.DeleteMentors(id);
        }

        [HttpPost("Mentors")]
        public void AddAdmin([FromBody] Admin admin)
        {
            _usersRepository.AddAdmin(admin);
        }
    }
}

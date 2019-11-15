using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MOD.AuthenticationService.Models;
using MOD.AuthenticationService.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MOD.AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public AuthenticationController
            (IAuthenticationRepository _authenticationRepository)
        {
            authenticationRepository = _authenticationRepository;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Works");
        }

        [HttpPost("User")]
        public ActionResult<string> PostUsers([FromBody] User user)
        {
            if (authenticationRepository.AuthenticateUser(user))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.userName)
                };

                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("MyKeyForAuthentication"));

                var token = new JwtSecurityToken(
                        issuer: "iiht.com",
                        audience: "trainees",
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials:
                            new SigningCredentials(signingKey,
                                SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new TokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost("Mentor")]
        public ActionResult<string> PostMentors([FromBody] Admin admin)
        {
            if (authenticationRepository.AuthenticateAdmin(admin))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, admin.userName)
                };

                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("MyKeyForAuthentication"));

                var token = new JwtSecurityToken(
                        issuer: "iiht.com",
                        audience: "trainees",
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials:
                            new SigningCredentials(signingKey,
                                SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new TokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost("Admin")]
        public ActionResult<string> PostMentors([FromBody] Mentor mentor)
        {
            if (authenticationRepository.AuthenticateMentor(mentor))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, mentor.userName)
                };

                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("MyKeyForAuthentication"));

                var token = new JwtSecurityToken(
                        issuer: "iiht.com",
                        audience: "trainees",
                        expires: DateTime.Now.AddHours(1),
                        claims: claims,
                        signingCredentials:
                            new SigningCredentials(signingKey,
                                SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new TokenResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}

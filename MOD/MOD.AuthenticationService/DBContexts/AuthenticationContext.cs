using Microsoft.EntityFrameworkCore;
using MOD.AuthenticationService.Models;

namespace MOD.AuthenticationService.DBContexts
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext
            (DbContextOptions<AuthenticationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

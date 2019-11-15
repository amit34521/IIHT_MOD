using Microsoft.EntityFrameworkCore;
using MOD.UserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.UserService.DBContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorSkill> MentorSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

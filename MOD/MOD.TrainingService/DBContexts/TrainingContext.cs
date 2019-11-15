using Microsoft.EntityFrameworkCore;
using MOD.TrainingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TrainingService.DBContexts
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) 
            : base(options)
        {

        }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}

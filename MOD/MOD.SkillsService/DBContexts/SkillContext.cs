using Microsoft.EntityFrameworkCore;
using MOD.SkillsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.SkillsService.DBContexts
{
    public class SkillContext : DbContext
    {
        public SkillContext(DbContextOptions<SkillContext> options) : base(options)
        {

        }
        public DbSet<Skill> Skills { get; set; }
    }
}

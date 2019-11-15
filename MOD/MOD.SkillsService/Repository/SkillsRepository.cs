using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.SkillsService.DBContexts;
using MOD.SkillsService.Models;

namespace MOD.SkillsService.Repository
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly SkillContext _dbContext;

        public SkillsRepository(SkillContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void AddSkill(Skill skill)
        {
            _dbContext.Add(skill);
            Save();
        }

        public void DeleteSkill(long id)
        {
            Skill skill = _dbContext.Skills.Find(id);
            _dbContext.Skills.Remove(skill);
            Save();
        }

        public List<Skill> GetSkills()
        {
            return _dbContext.Skills.ToList();
        }

        public void UpdateSkill(Skill skill)
        {
            var skillItem = _dbContext.Skills.First(x => 
            x.Name.Equals(skill.Name, StringComparison.OrdinalIgnoreCase));
            if(skillItem != null)
            {
                skillItem.Prerequisites = skill.Prerequisites;
                skillItem.TOC = skill.TOC;
                skillItem.duration = skill.duration;
                Save();
            }
        }

        public Skill GetSkillByName(string name)
        {
            return _dbContext.Skills.FirstOrDefault
                (x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Skill GetSkillById(long id)
        {
            return _dbContext.Skills.FirstOrDefault
                (x => x.ID == id);
        }
    }
}

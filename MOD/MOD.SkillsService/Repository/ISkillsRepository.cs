using MOD.SkillsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.SkillsService.Repository
{
    public interface ISkillsRepository
    {
        List<Skill> GetSkills();
        void AddSkill(Skill skill);
        void UpdateSkill(Skill technology);
        void DeleteSkill(long id);
        Skill GetSkillByName(string name);
        Skill GetSkillById(long id);
    }
}

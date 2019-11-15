using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.SkillsService.Models;
using MOD.SkillsService.Repository;

namespace MOD.SkillsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsRepository _technologyRepository;
        public SkillsController(ISkillsRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        // GET: api/Skills
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_technologyRepository.GetSkills());
        }

        // GET: api/Skills/5
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            var skillItem = _technologyRepository.GetSkillByName(name);
            if(skillItem == null)
            {
                return NoContent();
            }
            return Ok(skillItem);
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<string> GetbyID(long id)
        {
            var skillItem = _technologyRepository.GetSkillById(id);
            if (skillItem == null)
            {
                return NoContent();
            }
            return Ok(skillItem);
        }

        // POST: api/Skills
        [HttpPost]
        public void Post([FromBody] Skill skill)
        {
            _technologyRepository.AddSkill(skill);
        }

        // PUT: api/Skills/5
        [HttpPut]
        public void Put(Skill skill)
        {
            _technologyRepository.UpdateSkill(skill);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(long id)
        {
            _technologyRepository.DeleteSkill(id);
        }
    }
}

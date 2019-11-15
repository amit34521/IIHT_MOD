using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.SearchService.Repository;

namespace MOD.SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        public ActionResult<string>GetByTechnologyName(string name)
        {
            var result = _searchRepository.GetTrainingsBySkill(name);
            if(result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NoContent();
        }
    }
}
using MOD.SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.SearchService.Repository
{
    public interface ISearchRepository
    {
        List<Training> GetTrainingsBySkill(string name);
    }
}

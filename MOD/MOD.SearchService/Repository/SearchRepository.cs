using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.SearchService.DBContexts;
using MOD.SearchService.Models;

namespace MOD.SearchService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly SearchContext searchContext;

        public SearchRepository(SearchContext _searchContext)
        {
            searchContext = _searchContext;
        }

        public List<Training> GetTrainingsBySkill(string name)
        {
            var result = searchContext.Trainings
                .Where(x => x.skillName
                .Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return result;
        }
    }
}

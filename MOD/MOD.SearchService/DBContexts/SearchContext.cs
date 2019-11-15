using Microsoft.EntityFrameworkCore;
using MOD.SearchService.Models;

namespace MOD.SearchService.DBContexts
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions<SearchContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}

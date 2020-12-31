using Microsoft.EntityFrameworkCore;

namespace FinalTestApi.Models
{
    public class LeagueContext:DbContext
    {
        public LeagueContext(DbContextOptions<LeagueContext> opts):base(opts)
        {
            
        }
        public DbSet<Match> Matches { get;set; }
        public DbSet<Team> Teams{get;set;}
        public DbSet<Player> Players{get;set;}
        public DbSet<Result> Results{get;set;}
        public DbSet<Score> Scores{get;set;}
        public DbSet<Stadium> Stadiums{get;set;}
    }
}
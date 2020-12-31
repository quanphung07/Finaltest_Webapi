using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTestApi.Dtos;
using FinalTestApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FinalTestApi.Data
{
    public interface IDataRepo
    {
        //Team Data
        Task<Team> GetTeamByNameAsync(string name);
        Task<Team> GetTeamByIdAsync(int id);
        Task<int> CreateTeamAsync(Team team);
        Task<Team> GetTeamAsync(int? id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        
      
                //Player Data
        Task<Player> GetPlayerByIdAsync(int? id);
        Task <int> CreatePlayerAsync(Player player);
        Task<int> UpdatePlayerAsync(int id,Player player);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
       // Task<Player> UpdatePlayerAsync_ver1(int id,JsonPatchDocument<Player> player);
        //Stadium data
        Task<Stadium> GetStadiumByNameAsync(string name);
        Task<bool> SaveChangesAsync();
        
        //match data
        Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync();
        Task<int> CreateMatchAsync(Match match);
        Task<bool> checkExist(int homeId,int awayId);
        Task<MatchInfoDtos> GetMatchByIdAsync(int matchId);

        //result data
        Task<int> CreateResultAsync(Result result);
        //score data
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<int> CreateScoreAsync(Score score);

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTestApi.Data;
using FinalTestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalTestApi.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController:ControllerBase
    {
        private readonly IDataRepo _repo;
        public TeamController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await _repo.GetAllTeamsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            return Ok(await _repo.GetTeamByIdAsync(id));
        }

        
    }
}
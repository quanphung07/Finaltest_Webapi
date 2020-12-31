using System.Threading.Tasks;
using FinalTestApi.Data;
using FinalTestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalTestApi.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController:ControllerBase
    {
        private readonly IDataRepo _repo;
        public MatchController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> GetAllMatches()
        {
            return Ok(await _repo.GetAllMatchAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _repo.GetMatchByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            return Ok(await _repo.CreateMatchAsync(match));
        }
        
    }
}
using System.Threading.Tasks;
using FinalTestApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalTestApi.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class ScoreController:ControllerBase
    {
        private readonly IDataRepo _repo;
        public ScoreController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> GetAllScores()
        {
            return Ok(await _repo.GetAllScoresAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _repo.GetMatchByIdAsync(id));
        }
        
    }
}
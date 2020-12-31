using System;
using System.Threading.Tasks;
using FinalTestApi.Data;
using FinalTestApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace FinalTestApi.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController:ControllerBase
    {
        private readonly IDataRepo _repo;
        public PlayerController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> GetAllPlayers()
        {
            return Ok(await _repo.GetAllPlayersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _repo.GetPlayerByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            return Ok(await _repo.CreatePlayerAsync(player));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id,[FromBody] Player player)
        {
            return Ok(await _repo.UpdatePlayerAsync(id,player) );
        }
      

        
    }
}
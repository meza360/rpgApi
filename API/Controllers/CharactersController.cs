using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly DataContext _context;

        public CharactersController(ILogger<CharactersController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("characters")]
        public async Task<ActionResult<List<Character>>> GetCharacters(){
            return await _context.Characters.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id){
            Character? ch = await _context.Characters.FindAsync(id);
            if(ch != null) return ch;

            return NoContent();
            
        }
    }
}
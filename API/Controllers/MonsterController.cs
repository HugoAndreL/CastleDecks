using API.Data;
using API.Data.DTO_s.MonstersDTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public MonsterController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Monster
        /// </summary>
        /// <param name="monsterDTO">*Necessary field: Monster data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Monster Created!</response>
        /// <response code="500">Failure: Monster cannot be created because the Category does not exist!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateMonster([FromBody] CreateMonsterDTO monsterDTO)
        {
            Monsters monster = _mapper.Map<Monsters>(monsterDTO);
            _context.Monsters.Add(monster);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchMonster), new { id = monster.Id_Monster }, monster);
        }

        /// <summary>
        ///     Return the Entire Monster
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Monster Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadMonsterDTO> GetMonster([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadMonsterDTO>>(_context.Monsters.Skip(skip).Take(take).ToList());
        }

        /// <summary>
        ///     Searches for a Monster
        /// </summary>
        /// <param name="id">*Necessary field: Monster ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Monster not found!</response>
        /// <response code="200">Success: Monster found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchMonster(int id)
        {
            Monsters monster = _context.Monsters.FirstOrDefault(monster => monster.Id_Monster == id);
            if (monster != null)
            {
                ReadMonsterDTO monsterDTO = _mapper.Map<ReadMonsterDTO>(monster);
                return Ok(monsterDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Update a Monster
        /// </summary>
        /// <param name="id">*Necessary field: Monster ID!</param>
        /// <param name="monsterDTO">*Necessary field: Monster data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Monster not found!</response>
        /// <response code="204">Success: Monster found and Updated!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateMonster(int id, [FromBody] UpdateMonsterDTO monsterDTO)
        {
            var monster = _context.Monsters.FirstOrDefault(monster => monster.Id_Monster == id);
            if (monster == null) return NotFound();
            _mapper.Map(monsterDTO, monster);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        ///     Deleted a Monster
        /// </summary>
        /// <param name="id">*Necessary field: Monster ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Monster not found!</response>
        /// <response code="204">Success: Monster Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteMonsters(int id)
        {
            var monster = _context.Monsters.FirstOrDefault(monster => monster.Id_Monster == id);
            if (monster == null) return NotFound();
            _context.Remove(monster);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

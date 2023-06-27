using API.Data.DTO_s.SpellDTO;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public SpellController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Spell
        /// </summary>
        /// <param name="spellDTO">*Necessary field: Spell data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Spell Created!</response>
        /// <response code="500">Failure: Spell cannot be created because the Category does not exist!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateSpell([FromBody] CreateSpellDTO spellDTO)
        {
            Spell spell = _mapper.Map<Spell>(spellDTO);
            _context.Spells.Add(spell);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchSpell), new { id = spell.Id_Spell }, spell);
        }

        /// <summary>
        ///     Return the Entire Spells
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Spells Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadSpellDTO> GetSpell()
        {
            return _mapper.Map<List<ReadSpellDTO>>(_context.Spells.ToList());
        }

        /// <summary>
        ///     Searches for a Spell
        /// </summary>
        /// <param name="id">*Necessary field: Spell ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Spell not found!</response>
        /// <response code="200">Success: Spell found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchSpell(int id)
        {
            Spell spell = _context.Spells.FirstOrDefault(spell => spell.Id_Spell == id);
            if (spell != null)
            {
                ReadSpellDTO spellDTO = _mapper.Map<ReadSpellDTO>(spell);
                return Ok(spellDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Update a Spell
        /// </summary>
        /// <param name="id">*Necessary field: Spell ID!</param>
        /// <param name="SpellDTO">*Necessary field: Spell data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Spell not found!</response>
        /// <response code="204">Success: Spell found and Updated!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateSpell(int id, [FromBody] UpdateSpellDTO spellDTO)
        {
            var spell = _context.Spells.FirstOrDefault(spell => spell.Id_Spell == id);
            if (spell == null) return NotFound();
            _mapper.Map(spellDTO, spell);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        ///     Deleted a Spell
        /// </summary>
        /// <param name="id">*Necessary field: Spell ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Spell not found!</response>
        /// <response code="204">Success: Spell Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteSpells(int id)
        {
            var spell = _context.Spells.FirstOrDefault(spell => spell.Id_Spell == id);
            if (spell == null) return NotFound();
            _context.Remove(spell);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

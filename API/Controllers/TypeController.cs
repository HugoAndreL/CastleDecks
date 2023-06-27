using Microsoft.AspNetCore.Mvc;
using API.Data.DTO_s.TypeDTO;
using API.Data;
using API.Models;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public TypeController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Type to Weapon
        /// </summary>
        /// <param name="typeDTO">*Necessary field: Type to Weapon data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Type to Weapon Created!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateType([FromBody] CreateTypeDTO typeDTO)
        {
            TypeWeapon type = _mapper.Map<TypeWeapon>(typeDTO);
            _context.TypesWeapons.Add(type);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchType), new { id = type.Id_TypeWeapon }, type);
        }

        /// <summary>
        ///     Return the Entire Categories
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Categories Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadTypeDTO> GetType([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadTypeDTO>>(_context.TypesWeapons.Skip(skip).Take(take).ToList());
        }

        /// <summary>
        ///     Searches for a Type to Weapon
        /// </summary>
        /// <param name="id">*Necessary field: Type to Weapon ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Type to Weapon not found!</response>
        /// <response code="200">Success: Type to Weapon found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchType(int id)
        {
            TypeWeapon type = _context.TypesWeapons.FirstOrDefault(type => type.Id_TypeWeapon == id);
            if (type != null)
            {
                ReadTypeDTO typeDTO = _mapper.Map<ReadTypeDTO>(type);
                return Ok(typeDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Deleted a Type to Weapon
        /// </summary>
        /// <param name="id">*Necessary field: Type to Weapon ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Type to Weapon not found!</response>
        /// <response code="204">Success: Type to Weapon Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteTypeWeapon(int id)
        {
            var type = _context.TypesWeapons.FirstOrDefault(type => type.Id_TypeWeapon == id);
            if (type == null) return NotFound();
            _context.Remove(type);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

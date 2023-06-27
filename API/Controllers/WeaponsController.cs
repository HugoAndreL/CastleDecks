using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Data.DTO_s.WeaponDTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public WeaponController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Weapon
        /// </summary>
        /// <param name="weaponDTO">*Necessary field: Weapon data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Weapon Created!</response>
        /// <response code="500">Failure: Weapon cannot be created because the Category does not exist!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateWeapon([FromBody] CreateWeaponDTO weaponDTO)
        {
            Weapons weapon = _mapper.Map<Weapons>(weaponDTO);
            _context.Weapons.Add(weapon);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchWeapon), new { id = weapon.Id_Weapon }, weapon);
        }

        /// <summary>
        ///     Return the Entire Weapons
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Weapons Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadWeaponDTO> GetWeapon()
        {
            return _mapper.Map<List<ReadWeaponDTO>>(_context.Weapons.ToList());
        }

        /// <summary>
        ///     Searches for a Weapon
        /// </summary>
        /// <param name="id">*Necessary field: Weapon ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Weapon not found!</response>
        /// <response code="200">Success: Weapon found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchWeapon(int id)
        {
            Weapons weapon = _context.Weapons.FirstOrDefault(weapon => weapon.Id_Weapon == id);
            if (weapon != null)
            {
                ReadWeaponDTO weaponDTO = _mapper.Map<ReadWeaponDTO>(weapon);
                return Ok(weaponDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Update a Weapon
        /// </summary>
        /// <param name="id">*Necessary field: Weapon ID!</param>
        /// <param name="weaponDTO">*Necessary field: Weapon data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Weapon not found!</response>
        /// <response code="204">Success: Weapon found and Updated!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateWeapon(int id, [FromBody] UpdateWeaponDTO weaponDTO)
        {
            var weapon = _context.Weapons.FirstOrDefault(Weapon => Weapon.Id_Weapon == id);
            if (weapon == null) return NotFound();
            _mapper.Map(weaponDTO, weapon);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        ///     Deleted a Weapon
        /// </summary>
        /// <param name="id">*Necessary field: Weapon ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Weapon not found!</response>
        /// <response code="204">Success: Weapon Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteWeapons(int id)
        {
            var weapon = _context.Weapons.FirstOrDefault(Weapon => Weapon.Id_Weapon == id);
            if (weapon == null) return NotFound();
            _context.Remove(weapon);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

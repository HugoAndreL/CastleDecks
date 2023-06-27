using API.Data;
using API.Data.DTO_s.FamiliarsDTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliarController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public FamiliarController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Familiar
        /// </summary>
        /// <param name="familiarDTO">*Necessary field: Familiar data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Familiar Created!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateFamiliars([FromBody] CreateFamiliarsDTO familiarDTO)
        {
            Familiar familiar = _mapper.Map<Familiar>(familiarDTO);
            _context.Familiars.Add(familiar);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchFamiliar), new { id = familiar.Id_Familiar }, familiar);
        }

        /// <summary>
        ///     Return the Entire Familiars
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Familiars Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFamiliar([FromQuery] int skip = 0, [FromQuery] int take = 50) 
        {
            return Ok(_mapper.Map<List<ReadFamiliarsDTO>>(_context.Familiars.Skip(skip).Take(take).ToList()));
        }

        /// <summary>
        ///     Searches for a Familiar
        /// </summary>
        /// <param name="id">*Necessary field: Familiar ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Familiar not found!</response>
        /// <response code="200">Success: Familiar found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchFamiliar(int id)
        {
            Familiar familiar = _context.Familiars.FirstOrDefault(familiar => familiar.Id_Familiar == id);
            if (familiar != null)
            {
                ReadFamiliarsDTO familiarDTO = _mapper.Map<ReadFamiliarsDTO>(familiar);
                return Ok(familiarDTO);
            }
            return NotFound();
        }
       
        /// <summary>
        ///     Update a Familiar
        /// </summary>
        /// <param name="id">*Necessary field: Familiar ID!</param>
        /// <param name="familiarDTO">*Necessary field: Familiar data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Familiar not found!</response>
        /// <response code="204">Success: Familiar found and Updated!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateFamiliar(int id, [FromBody] UpdateFamiliarsDTO familiarDTO)
        {
            var familiar = _context.Familiars.FirstOrDefault(familiar => familiar.Id_Familiar == id);
            if (familiar == null) return NotFound();
            _mapper.Map(familiarDTO, familiar);
            _context.SaveChanges();
            return NoContent();
        }


        /// <summary>
        ///     Deleted a Familiar
        /// </summary>
        /// <param name="id">*Necessary field: Familiar ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Familiar not found!</response>
        /// <response code="204">Success: Familiar Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteFamiliar(int id)
        {
            var familiar = _context.Familiars.FirstOrDefault(familiar => familiar.Id_Familiar == id);
            if (familiar == null) return NotFound();
            _context.Remove(familiar);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

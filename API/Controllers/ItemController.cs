using API.Data.DTO_s.ItemDTO;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public ItemController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Item
        /// </summary>
        /// <param name="itemDTO">*Necessary field: Item data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Item Created!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateItem([FromBody] CreateItemDTO itemDTO)
        {
            Item item = _mapper.Map<Item>(itemDTO);
            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchItem), new { id = item.Id_Item }, item);
        }

        /// <summary>
        ///     Return the Entire Item
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Item Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadItemDTO> GetItem([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadItemDTO>>(_context.Items.Skip(skip).Take(take).ToList());
        }

        /// <summary>
        ///     Searches for a Item
        /// </summary>
        /// <param name="id">*Necessary field: Item ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Item not found!</response>
        /// <response code="200">Success: Item found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchItem(int id)
        {
            Item item = _context.Items.FirstOrDefault(item => item.Id_Item == id);
            if (item != null)
            {
                ReadItemDTO itemDTO = _mapper.Map<ReadItemDTO>(item);
                return Ok(itemDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Update a Item
        /// </summary>
        /// <param name="id">*Necessary field: Item ID!</param>
        /// <param name="itemDTO">*Necessary field: Item data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Item not found!</response>
        /// <response code="204">Success: Item found and Updated!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateItem(int id, [FromBody] UpdateItemDTO itemDTO)
        {
            var item = _context.Items.FirstOrDefault(item => item.Id_Item == id);
            if (item == null) return NotFound();
            _mapper.Map(itemDTO, item);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        ///     Deleted a Item
        /// </summary>
        /// <param name="id">*Necessary field: Item ID</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Item not found!</response>
        /// <response code="204">Success: Item Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(item => item.Id_Item == id);
            if (item == null) return NotFound();
            _context.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

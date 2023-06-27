using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Data.DTO_s.ItemMonsterDTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemMonsterController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public ItemMonsterController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a Relation ItemMonster
        /// </summary>
        /// <param name="NN_DTO">*Necessary field: ItemMonster data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Relation ItemMonster Created!</response>
        /// <response code="500">Failure: Relation ItemMonster cannot be created because the item or monster does not exist!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateItemMonster([FromBody] CreateItemMonsterDTO NN_DTO)
        {
            Item_and_Monster NN = _mapper.Map<Item_and_Monster>(NN_DTO);
            _context.ItemMonster.Add(NN);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchItemMonster), new { itemId = NN.ItemId, monsterId = NN.MonstersId }, NN);
        }

        /// <summary>
        ///     Return the Entire Relations ItemMonster
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Relations ItemMonsters Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadItemMonsterDTO> GetItemMonster()
        {
            return _mapper.Map<List<ReadItemMonsterDTO>>(_context.ItemMonster.ToList());
        }

        /// <summary>
        ///     Searches for a Relation ItemMonster
        /// </summary>
        /// <param name="itemId">*Necessary field: Item ID!</param>
        /// <param name="monsterId">*Necessary field: Monster ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Item or Monster not found!</response>
        /// <response code="200">Success: Relation ItemMonster found!</response>
        [HttpGet("{itemId}/{monsterId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchItemMonster(int itemId, int monsterId)
        {
            Item_and_Monster NN = _context.ItemMonster.FirstOrDefault(
                NN => NN.ItemId == itemId && NN.MonstersId == monsterId
            );
            if (NN != null)
            {
                ReadItemMonsterDTO NN_DTO = _mapper.Map<ReadItemMonsterDTO>(NN);
                return Ok(NN_DTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Deleted a Relation ItemMonster
        /// </summary>
        /// <param name="itemId">*Necessary field: Item ID!</param>
        /// <param name="itemId">*Necessary field: Monster ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Item or Monster not found!</response>
        /// <response code="204">Success: Relation ItemMonster Deleted!</response>
        [HttpDelete("{itemId}/{monsterId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteItemMonster(int itemId, int monsterId)
        {
            var NN = _context.ItemMonster.FirstOrDefault(
                NN => NN.ItemId == itemId && NN.MonstersId == monsterId
            );
            if (NN == null) return NotFound();
            _context.Remove(NN);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

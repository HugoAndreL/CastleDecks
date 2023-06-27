using API.Data;
using API.Data.DTO_s.CategoryDTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CastleDecksContext _context;
        private readonly IMapper _mapper;

        public CategoryController(CastleDecksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Create a category
        /// </summary>
        /// <param name="categoryDTO">*Necessary field: Category data!</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Success: Category Created!</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchCategory), new { id = category.Id_Category }, category);
        }

        /// <summary>
        ///     Return the Entire Categories
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Success: Categories Returned!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadCategoryDTO> GetCategory([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadCategoryDTO>>(_context.Categories.Skip(skip).Take(take).ToList());
        }

        /// <summary>
        ///     Searches for a Category
        /// </summary>
        /// <param name="id">*Necessary field: Category ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Category not found!</response>
        /// <response code="200">Success: Category found!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id_Category == id);
            if (category != null)
            {
                ReadCategoryDTO categoryDTO = _mapper.Map<ReadCategoryDTO>(category);
                return Ok(categoryDTO);
            }
            return NotFound();
        }

        /// <summary>
        ///     Deleted a Category
        /// </summary>
        /// <param name="id">*Necessary field: Category ID!</param>
        /// <returns>IActionResult</returns>
        /// <response code="404">Failure: Category not found!</response>
        /// <response code="204">Success: Category Deleted!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(category => category.Id_Category == id);
            if (category == null) return NotFound();
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

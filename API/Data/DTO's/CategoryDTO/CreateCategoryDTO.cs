using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "*The 'Name_Category' field is required!")]
        public string Name_Category { get; set; }
    }
}

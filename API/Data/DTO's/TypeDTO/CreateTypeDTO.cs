using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.TypeDTO
{
    public class CreateTypeDTO
    {
        [Required(ErrorMessage = "*The 'Name_TypeWeapon' field is required!")]
        public string Name_TypeWeapon { get; set; }
    }
}

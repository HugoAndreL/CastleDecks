using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.WeaponDTO
{
    public class CreateWeaponDTO
    {
        [Required(ErrorMessage = "*The 'Img_Weapon' field is required!")]
        public string Img_Weapon { get; set; }
        [Required(ErrorMessage = "*The 'Name_Weapon' field is required!")]
        public string Name_Weapon { get; set; }
        [StringLength(50, ErrorMessage = "*The 'Description_Prod' field only allows 30 characters!")]
        public string Description_Weapon { get; set; }
        public string Find_Weapon { get; set; }
        public string? Status_Weapon { get; set; }
        public string? Magic_Weapon { get; set; }
        [Required(ErrorMessage = "*The 'TypeWeapon' field is required, because the TypeWeapon does not exist!")]
        public int TypeWeaponId { get; set; }
    }
}

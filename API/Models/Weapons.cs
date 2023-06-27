using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Weapons
    {
        [Key]
        [Required]
        public int Id_Weapon { get; set; }
        [Required(ErrorMessage = "*The 'Img_Weapon' field is required!")]
        public string Img_Weapon { get; set; }
        [Required(ErrorMessage = "*The 'Name_Weapon' field is required!")]
        public string Name_Weapon { get; set; }
        [StringLength(50, ErrorMessage = "The 'Description_Prod' field only allows 30 characters")]
        public string? Description_Weapon { get; set; }
        public string? Status_Weapon { get; set; }
        public string? Find_Weapon { get; set; }
        public string? Magic_Weapon { get; set; }
        [Required]
        public int TypeWeaponId { get; set; }
        public virtual TypeWeapon TypeWeapon_Weapon { get; set; }
    }
}
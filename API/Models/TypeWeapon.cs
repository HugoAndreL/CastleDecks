using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TypeWeapon
    {
        [Key]
        [Required]
        public int Id_TypeWeapon { get; set; }
        [Required(ErrorMessage = "*The 'Name_TypeWeapon' field is required!")]
        public string Name_TypeWeapon { get; set; }
        public virtual ICollection<Weapons> Weapons_TypeWeapon { get; set; }
    }
}

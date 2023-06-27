using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id_Category { get; set; }
        [Required(ErrorMessage = "*The 'Name_Category' field is required!")]
        public string Name_Category { get; set; }
        public virtual ICollection<Monsters> Monsters_Category { get; set; }
    }
}

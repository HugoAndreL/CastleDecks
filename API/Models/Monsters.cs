using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Monsters
    {
        [Key]
        [Required]
        public int Id_Monster { get; set; }
        [Required(ErrorMessage = "*The 'NO_Monster' field is required!")]
        public int NO_Monster { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category_Monster { get; set; }
        [Required(ErrorMessage = "*The 'Name_Monster' field is required!")]
        public string Name_Monster { get; set; }
        public int? LV_Monster { get; set; } = null;
        public int? HP_Monster { get; set; } = null;
        public string Img_Monster { get; set; }
        public int? Strong_Monster { get; set; } = null;
        public int? Immune_Monster { get; set; } = null;
        public int? Weak_Monster { get; set; } = null;
        public int? Absorb_Monster { get; set; } = null;
        public virtual ICollection<Item_and_Monster> DropItems_Monster { get; set; }
        public int? EXP_Monster { get; set; } = null;
        public string Desc_Monster { get; set; }

    }
}

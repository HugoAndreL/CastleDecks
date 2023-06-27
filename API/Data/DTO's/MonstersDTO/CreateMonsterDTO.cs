using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.MonstersDTO
{
    public class CreateMonsterDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "*The 'NO_Monster' field is required!")]
        public int NO_Monster { get; set; }
        [Required(ErrorMessage = "*The 'Name_Monster' field is required!")]
        public string Name_Monster { get; set; }
        public int? LV_Monster { get; set; } = null;
        public int? HP_Monster { get; set; } = null;
        public string Img_Monster { get; set; }
        public int? Strong_Monster { get; set; } = null;
        public int? Immune_Monster { get; set; } = null;
        public int? Weak_Monster { get; set; } = null;
        public int? Absorb_Monster { get; set; } = null;
        public int? EXP_Monster { get; set; } = null;
        public string Desc_Monster { get; set; }
    }
}

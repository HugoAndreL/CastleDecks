using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Spell
    {
        [Key]
        [Required]
        public int Id_Spell { get; set; }
        [Required(ErrorMessage = "*The 'Name_Spell' field is required!")]
        public string Name_Spell { get; set; }
        public string? Desc_Spell { get; set; }
        [Required(ErrorMessage = "*The 'HowDo_Spell' field is required!")]
        public string HowDo_Spell { get; set; }
        public virtual Familiar? Familiar_Spell { get; set; }
    }
}

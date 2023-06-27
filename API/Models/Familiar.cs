using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Familiar
    {
        [Key]
        [Required]
        public int Id_Familiar { get; set; }
        [Required(ErrorMessage = "*The 'Img_Familiars' field is required!")]
        public string Img_Familiar { get; set; }
        [Required(ErrorMessage = "*The 'Name_Familiars' field is required!")]
        public string Name_Familiar { get; set; }
        public string? Phrase_Familiar { get; set; }
        public int? SpellId { get; set; }
        public virtual Spell? Spell_Familiar { get; set; }
    }
}

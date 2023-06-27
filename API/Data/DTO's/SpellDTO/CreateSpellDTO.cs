using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.SpellDTO
{
    public class CreateSpellDTO
    {
        [Required(ErrorMessage = "*The 'Name_Spell' field is required!")]
        public string Name_Spell { get; set; }
        public string? Desc_Spell { get; set; }
        public string HowDo_Spell { get; set; }
    }
}

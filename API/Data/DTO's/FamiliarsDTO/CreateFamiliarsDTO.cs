using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.FamiliarsDTO
{
    public class CreateFamiliarsDTO
    {
        [Required(ErrorMessage = "*The 'Img_Familiars' field is required!")]
        public string Img_Familiar { get; set; }
        [Required(ErrorMessage = "*The 'Name_Familiars' field is required!")]
        public string Name_Familiar { get; set; }
        public string? Phrase_Familiar { get; set; }
        public int? SpellId { get; set; }
    }
}

using API.Data.DTO_s.SpellDTO;

namespace API.Data.DTO_s.FamiliarsDTO
{
    public class ReadFamiliarsDTO
    {
        public int Id_Familiar { get; set; }
        public string Img_Familiar { get; set; }
        public string Name_Familiar { get; set; }
        public string? Phrase_Familiar { get; set; }
        public ReadSpellDTO? Spell_Familiar { get; set; }
    }
}

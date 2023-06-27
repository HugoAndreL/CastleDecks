using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.RelicsDTO
{
    public class ReadRelicsDTO
    {
        public int Id_Relic { get; set; }
        public string Img_Relic { get; set; }
        public string Name_Relic { get; set; }
        public string? Description_Relic { get; set; }
        public string? Attrib_Relic { get; set; }
        public string? Consume_Relic { get; set; }
        public string? Found_Relic { get; set; }
    }
}

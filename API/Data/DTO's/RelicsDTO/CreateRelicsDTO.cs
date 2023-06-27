using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.RelicsDTO
{
    public class CreateRelicsDTO
    {
        [Required(ErrorMessage = "*The 'Img_Relic' field is required!")]
        public string Img_Relic { get; set; }
        [Required(ErrorMessage = "*The 'Name_Relic' field is required!")]
        public string Name_Relic { get; set; }
        [StringLength(50, ErrorMessage = "The 'Description_Relic' field only allows 50 characters")]
        public string? Description_Relic { get; set; }
        public string? Attrib_Relic { get; set; }
        public string? Consume_Relic { get; set; }
        public string? Found_Relic { get; set; }
    }
}

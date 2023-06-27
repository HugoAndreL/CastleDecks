using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.ItemDTO
{
    public class UpdateItemDTO
    {
        public string Img_Item { get; set; }
        [Required(ErrorMessage = "*The 'Name_Item' field is necessary!")]
        public string Name_Item { get; set; }
        public string Desc_Item { get; set; }
        public string? Stats_Item { get; set; } = null;
        public string HowFound_Item { get; set; }
    }
}

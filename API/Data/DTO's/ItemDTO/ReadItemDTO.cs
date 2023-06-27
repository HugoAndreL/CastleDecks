using API.Data.DTO_s.ItemMonsterDTO;

namespace API.Data.DTO_s.ItemDTO
{
    public class ReadItemDTO
    {
        public int Id_Item { get; set; }
        public string Img_Item { get; set; }
        public string Name_Item { get; set; }
        public string Desc_Item { get; set; }
        public string? Stats_Item { get; set; } = null;
        public string HowFound_Item { get; set; }
        public virtual ICollection<ReadItemMonsterDTO> ItemsMonsters { get; set; }
    }
}

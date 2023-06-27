using API.Data.DTO_s.ItemDTO;
using API.Data.DTO_s.MonstersDTO;

namespace API.Data.DTO_s.CategoryDTO
{
    public class ReadCategoryDTO
    {
        public int Id_Category { get; set; }
        public string Name_Category { get; set; }
        public virtual ICollection<ReadMonsterDTO> Monsters_Category { get; set; }
    }
}

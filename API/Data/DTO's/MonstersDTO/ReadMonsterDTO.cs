using API.Data.DTO_s.ItemMonsterDTO;

namespace API.Data.DTO_s.MonstersDTO
{
    public class ReadMonsterDTO
    {
        public int Id_Monster { get; set; }
        public int NO_Monster { get; set; }
        public string Name_Monster { get; set; }
        public int? LV_Monster { get; set; }
        public int? HP_Monster { get; set; }
        public string Img_Monster { get; set; }
        public int? Strong_Monster { get; set; }
        public int? Immune_Monster { get; set; }
        public int? Weak_Monster { get; set; }
        public int? Absorb_Monster { get; set; }
        public virtual ICollection<ReadItemMonsterDTO> DropItems_Monster { get; set; }
        public int? EXP_Monster { get; set; }
        public string Desc_Monster { get; set; }
    }
}

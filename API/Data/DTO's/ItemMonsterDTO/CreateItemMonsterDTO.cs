using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO_s.ItemMonsterDTO
{
    public class CreateItemMonsterDTO
    {
        [Required]
        public int ItemId { get; set; }
        public int? MonstersId { get; set; }
    }
}

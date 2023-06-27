using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Item_and_Monster
    {
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int? MonstersId { get; set; }
        public virtual Monsters Monsters { get; set; }
    }
}

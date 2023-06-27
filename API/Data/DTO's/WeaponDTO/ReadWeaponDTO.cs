using API.Models;

namespace API.Data.DTO_s.WeaponDTO
{
    public class ReadWeaponDTO
    {
        public int Id_Weapon { get; set; }
        public string Img_Weapon { get; set; }
        public string Name_Weapon { get; set; }
        public string Description_Weapon { get; set; }
        public string Find_Weapon { get; set; }
        public string? Status_Weapon { get; set; }
        public string? Magic_Weapon { get; set; }
    }
}

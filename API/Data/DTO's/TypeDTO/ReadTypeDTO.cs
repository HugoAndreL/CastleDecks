using API.Data.DTO_s.WeaponDTO;

namespace API.Data.DTO_s.TypeDTO
{
    public class ReadTypeDTO
    {
        public int Id_TypeWeapon { get; set; }
        public string Name_TypeWeapon { get; set; }
        public virtual ICollection<ReadWeaponDTO> Weapons_TypeWeapon { get; set; }
    }
}

using AutoMapper;
using API.Models;
using API.Data.DTO_s.WeaponDTO;

namespace API.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<CreateWeaponDTO, Weapons>();
            CreateMap<Weapons, ReadWeaponDTO>();
            CreateMap<UpdateWeaponDTO, Weapons>();
        }
    }
}

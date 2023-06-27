using API.Data.DTO_s.TypeDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class TypeProfile
    {
        public class CategoryProfile : Profile
        {
            public CategoryProfile()
            {
                CreateMap<CreateTypeDTO, TypeWeapon>();
                CreateMap<TypeWeapon, ReadTypeDTO>()
                    .ForMember(typeDTO => typeDTO.Weapons_TypeWeapon,
                        opt => opt.MapFrom(type => type.Weapons_TypeWeapon));
            }
        }
    }
}

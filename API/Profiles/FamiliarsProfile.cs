using API.Data.DTO_s.FamiliarsDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class FamiliarsProfile : Profile
    {
        public FamiliarsProfile()
        {
            CreateMap<CreateFamiliarsDTO, Familiar>();
            CreateMap<Familiar, ReadFamiliarsDTO>()
                .ForMember(familiarDTO => familiarDTO.Spell_Familiar,
                        opt => opt.MapFrom(familiar => familiar.Spell_Familiar));
            CreateMap<UpdateFamiliarsDTO, Familiar>();
        }
    }
}

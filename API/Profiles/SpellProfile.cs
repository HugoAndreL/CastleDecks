using API.Data.DTO_s.SpellDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class SpellProfile : Profile
    {
        public SpellProfile()
        {
            CreateMap<CreateSpellDTO, Spell>();
            CreateMap<Spell, ReadSpellDTO>();
            CreateMap<UpdateSpellDTO, Spell>();
        }
    }
}

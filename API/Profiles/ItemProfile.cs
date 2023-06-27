using API.Data.DTO_s.ItemDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemDTO, Item>();
            CreateMap<Item, ReadItemDTO>()
                .ForMember(itemDTO => itemDTO.ItemsMonsters,
                    opt => opt.MapFrom(item => item.ItemsMonsters));
            CreateMap<UpdateItemDTO, Item>();
        }
    }
}

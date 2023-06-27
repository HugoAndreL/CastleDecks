using API.Data.DTO_s.ItemMonsterDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class ItemMonsterProfile : Profile
    {
        public ItemMonsterProfile() 
        {
            CreateMap<CreateItemMonsterDTO, Item_and_Monster>();
            CreateMap<Item_and_Monster, ReadItemMonsterDTO>();
        }
    }
}

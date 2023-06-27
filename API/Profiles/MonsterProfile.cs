using API.Data.DTO_s.MonstersDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class MonsterProfile : Profile
    {
        public MonsterProfile()
        {
            CreateMap<CreateMonsterDTO, Monsters>();
            CreateMap<Monsters, ReadMonsterDTO>()
                 .ForMember(monsterDTO => monsterDTO.DropItems_Monster,
                    opt => opt.MapFrom(monster => monster.DropItems_Monster));
            CreateMap<UpdateMonsterDTO, Monsters>();
        }
    }
}

using API.Data.DTO_s.CategoryDTO;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, ReadCategoryDTO>()
                .ForMember(categoryDTO => categoryDTO.Monsters_Category,
                    opt => opt.MapFrom(category => category.Monsters_Category));
        }
    }
}

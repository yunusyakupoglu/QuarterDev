using AutoMapper;
using DTOs;
using UI.Models;

namespace UI.Mappings.AutoMapper
{
    public class UIMapProfile : Profile
    {
        public UIMapProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
            CreateMap<AboutUsDescriptionViewModel, AUDescriptionCreateDto>().ReverseMap();
            CreateMap<QuarterCategoryTitlesViewModel, QuarterCategoryTitleCreateDto>().ReverseMap();
            CreateMap<CategorySubtitleViewModel, CategorySubtitleCreateDto>().ReverseMap();
            CreateMap<SubtitleItemViewModel, SubtitleItemCreateDto>().ReverseMap();
            CreateMap<SubtitleDescriptionViewModel, SubtitleDescriptionCreateDto>().ReverseMap();
            CreateMap<ProjectImageViewModel, ProjectImageCreateDto>().ReverseMap();
        }
    }
}

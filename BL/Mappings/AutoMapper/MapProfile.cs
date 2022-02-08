using AutoMapper;
using DTOs;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mappings.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppRoleCreateDto, ObjAppRole>().ReverseMap();
            CreateMap<AppRoleListDto, ObjAppRole>().ReverseMap();
            CreateMap<AppRoleUpdateDto, ObjAppRole>().ReverseMap();

            CreateMap<AppUserCreateDto, ObjAppUser>().ReverseMap();
            CreateMap<AppUserListDto, ObjAppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, ObjAppUser>().ReverseMap();

            CreateMap<BlogAppUserStatusCreateDto, ObjBlogAppUserStatus>().ReverseMap();
            CreateMap<BlogAppUserStatusListDto, ObjBlogAppUserStatus>().ReverseMap();
            CreateMap<BlogAppUserStatusUpdateDto, ObjBlogAppUserStatus>().ReverseMap();

            CreateMap<BlogCreateDto, ObjBlog>().ReverseMap();
            CreateMap<BlogListDto, ObjBlog>().ReverseMap();
            CreateMap<BlogUpdateDto, ObjBlog>().ReverseMap();

            CreateMap<AboutUsCreateDto, ObjAboutUs>().ReverseMap();
            CreateMap<AboutUsListDto, ObjAboutUs>().ReverseMap();
            CreateMap<AboutUsUpdateDto, ObjAboutUs>().ReverseMap();

            CreateMap<AUDescriptionCreateDto, ObjAUDescription>().ReverseMap();
            CreateMap<AUDescriptionListDto, ObjAUDescription>().ReverseMap();
            CreateMap<AUDescriptionUpdateDto, ObjAUDescription>().ReverseMap();

            CreateMap<QuarterCategoryCreateDto, ObjQuarterCategory>().ReverseMap();
            CreateMap<QuarterCategoryListDto, ObjQuarterCategory>().ReverseMap();
            CreateMap<QuarterCategoryUpdateDto, ObjQuarterCategory>().ReverseMap();

            CreateMap<QuarterCategoryTitleCreateDto, ObjQuarterCategoryTitle>().ReverseMap();
            CreateMap<QuarterCategoryTitleListDto, ObjQuarterCategoryTitle>().ReverseMap();
            CreateMap<QuarterCategoryTitleUpdateDto, ObjQuarterCategoryTitle>().ReverseMap();

            CreateMap<SubtitleItemCreateDto, ObjSubtitleItem>().ReverseMap();
            CreateMap<SubtitleItemListDto, ObjSubtitleItem>().ReverseMap();
            CreateMap<SubtitleItemUpdateDto, ObjSubtitleItem>().ReverseMap();

            CreateMap<SubtitleDescriptionCreateDto, ObjSubtitleDescription>().ReverseMap();
            CreateMap<SubtitleDescriptionListDto, ObjSubtitleDescription>().ReverseMap();
            CreateMap<SubtitleDescriptionUpdateDto, ObjSubtitleDescription>().ReverseMap();

            CreateMap<CategorySubtitleCreateDto, ObjCategorySubtitle>().ReverseMap();
            CreateMap<CategorySubtitleListDto, ObjCategorySubtitle>().ReverseMap();
            CreateMap<CategorySubtitleUpdateDto, ObjCategorySubtitle>().ReverseMap();
        }
    }
}

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

            CreateMap<ProjectCreateDto, ObjProject>().ReverseMap();
            CreateMap<ProjectListDto, ObjProject>().ReverseMap();
            CreateMap<ProjectUpdateDto, ObjProject>().ReverseMap();

            CreateMap<ProjectImageCreateDto, ObjProjectImage>().ReverseMap();
            CreateMap<ProjectImageListDto, ObjProjectImage>().ReverseMap();
            CreateMap<ProjectImageUpdateDto, ObjProjectImage>().ReverseMap();

            CreateMap<FaqCreateDto, ObjFaq>().ReverseMap();
            CreateMap<FaqListDto, ObjFaq>().ReverseMap();
            CreateMap<FaqUpdateDto, ObjFaq>().ReverseMap();

            CreateMap<CompanyServiceCreateDto, ObjCompanyService>().ReverseMap();
            CreateMap<CompanyServiceListDto, ObjCompanyService>().ReverseMap();
            CreateMap<CompanyServiceUpdateDto, ObjCompanyService>().ReverseMap();

            CreateMap<CustomerCreateDto, ObjCustomer>().ReverseMap();
            CreateMap<CustomerListDto, ObjCustomer>().ReverseMap();
            CreateMap<CustomerUpdateDto, ObjCustomer>().ReverseMap();
        }
    }
}

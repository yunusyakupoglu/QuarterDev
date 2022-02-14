using BL.IServices;
using BL.Services;
using BL.ValidationRules;
using DAL.UnitOfWork;
using DAL;
using DTOs;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IValidator<AppRoleCreateDto>, AppRoleCreateDtoValidator>();
            services.AddTransient<IValidator<AppRoleUpdateDto>, AppRoleUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<BlogAppUserStatusCreateDto>, BlogAppUserStatusCreateDtoValidator>();
            services.AddTransient<IValidator<BlogAppUserStatusUpdateDto>, BlogAppUserStatusUpdateDtoValidator>();

            services.AddTransient<IValidator<BlogCreateDto>, BlogCreateDtoValidator>();
            services.AddTransient<IValidator<BlogUpdateDto>, BlogUpdateDtoValidator>();

            services.AddTransient<IValidator<AboutUsCreateDto>, AboutUsCreateDtoValidator>();
            services.AddTransient<IValidator<AboutUsUpdateDto>, AboutUsUpdateDtoValidator>();

            services.AddTransient<IValidator<AUDescriptionCreateDto>, AUDescriptionCreateDtoValidator>();
            services.AddTransient<IValidator<AUDescriptionUpdateDto>, AUDescriptionUpdateDtoValidator>();

            services.AddTransient<IValidator<QuarterCategoryCreateDto>, QuarterCategoryCreateDtoValidator>();
            services.AddTransient<IValidator<QuarterCategoryUpdateDto>, QuarterCategoryUpdateDtoValidator>();

            services.AddTransient<IValidator<QuarterCategoryTitleCreateDto>, QuarterCategoryTitleCreateDtoValidator>();
            services.AddTransient<IValidator<QuarterCategoryTitleUpdateDto>, QuarterCategoryTitleUpdateDtoValidator>();

            services.AddTransient<IValidator<SubtitleItemCreateDto>, SubtitleItemCreateDtoValidator>();
            services.AddTransient<IValidator<SubtitleItemUpdateDto>, SubtitleItemUpdateDtoValidator>();

            services.AddTransient<IValidator<CategorySubtitleCreateDto>, CategorySubtitleCreateDtoValidator>();
            services.AddTransient<IValidator<CategorySubtitleUpdateDto>, CategorySubtitleUpdateDtoValidator>();

            services.AddTransient<IValidator<SubtitleDescriptionCreateDto>, SubtitleDescriptionCreateDtoValidator>();
            services.AddTransient<IValidator<SubtitleDescriptionUpdateDto>, SubtitleDescriptionUpdateDtoValidator>();

            services.AddTransient<IValidator<ProjectCreateDto>, ProjectCreateDtoValidator>();
            services.AddTransient<IValidator<ProjectUpdateDto>, ProjectUpdateDtoValidator>();

            services.AddTransient<IValidator<ProjectImageCreateDto>, ProjectImageCreateDtoValidator>();
            services.AddTransient<IValidator<ProjectImageUpdateDto>, ProjectImageUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddScoped<IAppRoleManager, AppRoleManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IBlogAppUserStatusManager, BlogAppUserStatusManager>();
            services.AddScoped<IBlogManager, BlogManager>();
            services.AddScoped<IAboutUsManager, AboutUsManager>();
            services.AddScoped<IAUDescriptionManager, AUDescriptionManager>();
            services.AddScoped<IQuarterCategoryManager, QuarterCategoryManager>();
            services.AddScoped<IQuarterCategoryTitleManager, QuarterCategoryTitleManager>();
            services.AddScoped<ISubtitleDescriptionManager, SubtitleDescriptionManager>();
            services.AddScoped<ICategorySubtitleManager, CategorySubtitleManager>();
            services.AddScoped<ISubtitleItemManager, SubtitleItemManager>();
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IProjectImageManager, ProjectImageManager>();
        }
    }
}

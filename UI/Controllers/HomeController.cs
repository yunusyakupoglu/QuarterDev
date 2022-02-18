using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAboutUsManager _aboutUs;
        private readonly IAUDescriptionManager _auDescription;
        private readonly IQuarterCategoryManager _quarterCategory;
        private readonly IQuarterCategoryTitleManager _quarterCategoryTitle;
        private readonly ICategorySubtitleManager _categorySubtitle;
        private readonly ISubtitleDescriptionManager _subtitleDescription;
        private readonly ISubtitleItemManager _subtitleItem;
        private readonly IProjectManager _project;
        private readonly IProjectImageManager _projectImage;
        private readonly IFaqManager _faq;
        private readonly ICompanyServiceManager _companyService;
        private readonly IValidator<AboutUsCreateDto> _aboutUsCreateDtoValidator;


		public HomeController(IMapper mapper, IAboutUsManager aboutUs, IAUDescriptionManager auDescription, IQuarterCategoryManager quarterCategory, IQuarterCategoryTitleManager quarterCategoryTitle, ICategorySubtitleManager categorySubtitle, ISubtitleDescriptionManager subtitleDescription, ISubtitleItemManager subtitleItem, IProjectManager project, IProjectImageManager projectImage, IFaqManager faq, ICompanyServiceManager companyService, IValidator<AboutUsCreateDto> aboutUsCreateDtoValidator)
		{
			_mapper = mapper;
			_aboutUs = aboutUs;
			_auDescription = auDescription;
			_quarterCategory = quarterCategory;
			_quarterCategoryTitle = quarterCategoryTitle;
			_categorySubtitle = categorySubtitle;
			_subtitleDescription = subtitleDescription;
			_subtitleItem = subtitleItem;
			_project = project;
			_projectImage = projectImage;
			_faq = faq;
			_companyService = companyService;
			_aboutUsCreateDtoValidator = aboutUsCreateDtoValidator;
		}
		public IActionResult Index()
        {
            HomeViewModel home = new HomeViewModel();
            home.faqs = _faq.GetActiveAsync().Result.Data;
            home.companyServices = _companyService.GetActiveAsync().Result.Data;
            home.projects = _project.GetActiveAsync().Result.Data;
            return View(home);
        }

        [Route("gizlilik")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("hakkimizda")]
        public IActionResult AboutUs()
        {
            HomeViewModel home = new HomeViewModel();
            home.abouts = _aboutUs.GetActiveAsync().Result.Data;
            home.aUDescriptions=_auDescription.GetActiveAsync().Result.Data;
            return View(home);
        }
        [HttpPost]
        public async Task<IActionResult> AboutUs(AboutUsCreateDto model)
        {
            var result = _aboutUsCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AboutUsCreateDto>(model);
                var createResponse = await _aboutUs.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
        [Route("quarter")]
        public IActionResult Quarter()
        {
            HomeViewModel home = new HomeViewModel();
            home.quarterCategories = _quarterCategory.GetActiveAsync().Result.Data;
            home.quarterCategoryTitles = _quarterCategoryTitle.GetActiveAsync().Result.Data;
            home.categorySubtitles = _categorySubtitle.GetActiveAsync().Result.Data;
            home.subtitleDescriptions = _subtitleDescription.GetActiveAsync().Result.Data;
            home.subtitleItems = _subtitleItem.GetActiveAsync().Result.Data;
            home.defaultCategoryTitle = home.quarterCategoryTitles[0] != null ? home.quarterCategoryTitles[0].Id : 1;
            return View(home);
        }
        [Route("projeler")]
        public IActionResult Projects()
        {
            HomeViewModel home = new HomeViewModel();
            home.projects = _project.GetActiveAsync().Result.Data;
            home.projectImages = _projectImage.GetActiveAsync().Result.Data;
            return View(home);
        }
        [Route("iletisim")]
        public IActionResult Contact()
        {
            HomeViewModel home = new HomeViewModel();
            home.projects = _project.GetActiveAsync().Result.Data;
            home.projectImages = _projectImage.GetActiveAsync().Result.Data;
            return View(home);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

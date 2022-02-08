using AutoMapper;
using BL.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(IMapper mapper, IAboutUsManager aboutUs, IAUDescriptionManager auDescription, IQuarterCategoryManager quarterCategory, IQuarterCategoryTitleManager quarterCategoryTitle, ICategorySubtitleManager categorySubtitle, ISubtitleDescriptionManager subtitleDescription, ISubtitleItemManager subtitleItem)
        {
            _mapper = mapper;
            _aboutUs = aboutUs;
            _auDescription = auDescription;
            _quarterCategory = quarterCategory;
            _quarterCategoryTitle = quarterCategoryTitle;
            _categorySubtitle = categorySubtitle;
            _subtitleDescription = subtitleDescription;
            _subtitleItem = subtitleItem;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            HomeViewModel home = new HomeViewModel();
            home.abouts = _aboutUs.GetActiveAsync().Result.Data;
            home.aUDescriptions=_auDescription.GetActiveAsync().Result.Data;
            return View(home);
        }

        public IActionResult Quarter()
        {
            HomeViewModel home = new HomeViewModel();
            home.quarterCategories = _quarterCategory.GetActiveAsync().Result.Data;
            home.quarterCategoryTitles = _quarterCategoryTitle.GetActiveAsync().Result.Data;
            home.categorySubtitles = _categorySubtitle.GetActiveAsync().Result.Data;
            home.subtitleDescriptions = _subtitleDescription.GetActiveAsync().Result.Data;
            home.subtitleItems = _subtitleItem.GetActiveAsync().Result.Data;
            return View(home);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsManager _aboutUsManager;
        private readonly IValidator<AboutUsCreateDto> _aboutUsCreateDtoValidator;
        private readonly IMapper _mapper;

        public AboutUsController(IAboutUsManager aboutUsManager, IValidator<AboutUsCreateDto> aboutUsCreateDtoValidator, IMapper mapper)
        {
            _aboutUsManager = aboutUsManager;
            _aboutUsCreateDtoValidator = aboutUsCreateDtoValidator;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var response = await _aboutUsManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _aboutUsManager.GetByIdAsync<AboutUsListDto>(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new AboutUsCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutUsCreateDto model)
        {
            var result = _aboutUsCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AboutUsCreateDto>(model);
                var createResponse = await _aboutUsManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _aboutUsManager.GetByIdAsync<AboutUsUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUsUpdateDto dto)
        {
            var response = await _aboutUsManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _aboutUsManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

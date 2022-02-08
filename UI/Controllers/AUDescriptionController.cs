using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class AUDescriptionController : Controller
    {
        private readonly IAUDescriptionManager _auManager;
        private readonly IAboutUsManager _aboutUsManager;
        private readonly IValidator<AUDescriptionCreateDto> _auCreateDtoValidator;
        private readonly IValidator<AboutUsDescriptionViewModel> _auvmCreateDtoValidator;
        private readonly IMapper _mapper;

        public AUDescriptionController(IAUDescriptionManager auManager, IValidator<AUDescriptionCreateDto> auCreateDtoValidator, IMapper mapper, IAboutUsManager aboutUsManager, IValidator<AboutUsDescriptionViewModel> auvmCreateDtoValidator)
        {
            _auManager = auManager;
            _auCreateDtoValidator = auCreateDtoValidator;
            _mapper = mapper;
            _aboutUsManager = aboutUsManager;
            _auvmCreateDtoValidator = auvmCreateDtoValidator;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _auManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _aboutUsManager.GetActiveAsync();
            var model = new AboutUsDescriptionViewModel
            {
                Abouts = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutUsDescriptionViewModel model)
        {
            var result = _auvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AUDescriptionCreateDto>(model);
                var createResponse = await _auManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _aboutUsManager.GetAllAsync();
            model.Abouts = new SelectList(response.Data, "Id", "Description", model.AboutUsId);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _auManager.GetByIdAsync<AUDescriptionUpdateDto>(id);
            var droplistResp = await _aboutUsManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AUDescriptionUpdateDto dto)
        {
            var response = await _auManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _auManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

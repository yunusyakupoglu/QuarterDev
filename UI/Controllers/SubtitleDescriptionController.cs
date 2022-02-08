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
    public class SubtitleDescriptionController : Controller
    {
        private readonly ISubtitleDescriptionManager _sdManager;
        private readonly ICategorySubtitleManager _csManager;
        private readonly IValidator<SubtitleDescriptionCreateDto> _sdCreateDtoValidator;
        private readonly IValidator<SubtitleDescriptionViewModel> _sdvmCreateDtoValidator;
        private readonly IMapper _mapper;

        public SubtitleDescriptionController(ISubtitleDescriptionManager sdManager, ICategorySubtitleManager csManager, IValidator<SubtitleDescriptionCreateDto> sdCreateDtoValidator, IValidator<SubtitleDescriptionViewModel> sdvmCreateDtoValidator, IMapper mapper)
        {
            _sdManager = sdManager;
            _csManager = csManager;
            _sdCreateDtoValidator = sdCreateDtoValidator;
            _sdvmCreateDtoValidator = sdvmCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _sdManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _csManager.GetActiveAsync();
            var model = new SubtitleDescriptionViewModel
            {
                CategorySubtitles = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubtitleDescriptionViewModel model)
        {
            var result = _sdvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<SubtitleDescriptionCreateDto>(model);
                var createResponse = await _sdManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _csManager.GetAllAsync();
            model.CategorySubtitles = new SelectList(response.Data, "Id", "Title", model.CategoySubtitleId);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _sdManager.GetByIdAsync<SubtitleDescriptionUpdateDto>(id);
            var droplistResp = await _csManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubtitleDescriptionUpdateDto dto)
        {
            var response = await _sdManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _sdManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

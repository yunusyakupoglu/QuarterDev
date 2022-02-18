using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class SubtitleItemController : Controller
    {
        private readonly ISubtitleItemManager _sıManager;
        private readonly ICategorySubtitleManager _csManager;
        private readonly IValidator<SubtitleItemCreateDto> _sıCreateDtoValidator;
        private readonly IValidator<SubtitleItemViewModel> _sıvmCreateDtoValidator;
        private readonly IMapper _mapper;

        public SubtitleItemController(ISubtitleItemManager sıManager, ICategorySubtitleManager csManager, IValidator<SubtitleItemCreateDto> sıCreateDtoValidator, IValidator<SubtitleItemViewModel> sıvmCreateDtoValidator, IMapper mapper)
        {
            _sıManager = sıManager;
            _csManager = csManager;
            _sıCreateDtoValidator = sıCreateDtoValidator;
            _sıvmCreateDtoValidator = sıvmCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _sıManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _csManager.GetActiveAsync();
            var model = new SubtitleItemViewModel
            {
                CategorySubtitles = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubtitleItemViewModel model)
        {
            var result = _sıvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<SubtitleItemCreateDto>(model);
                var createResponse = await _sıManager.CreateAsync(dto);
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
            var response = await _sıManager.GetByIdAsync<SubtitleItemUpdateDto>(id);
            var droplistResp = await _csManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubtitleItemUpdateDto dto)
        {
            var response = await _sıManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _sıManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

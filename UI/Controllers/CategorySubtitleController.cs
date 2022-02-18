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
    public class CategorySubtitleController : Controller
    {
        private readonly ICategorySubtitleManager _csManager;
        private readonly IQuarterCategoryTitleManager _qctManager;
        private readonly IValidator<CategorySubtitleCreateDto> _csCreateDtoValidator;
        private readonly IValidator<CategorySubtitleViewModel> _csvmCreateDtoValidator;
        private readonly IMapper _mapper;

        public CategorySubtitleController(ICategorySubtitleManager csManager, IQuarterCategoryTitleManager qctManager, IValidator<CategorySubtitleCreateDto> csCreateDtoValidator, IMapper mapper, IValidator<CategorySubtitleViewModel> csvmCreateDtoValidator)
        {
            _csManager = csManager;
            _qctManager = qctManager;
            _csCreateDtoValidator = csCreateDtoValidator;
            _mapper = mapper;
            _csvmCreateDtoValidator = csvmCreateDtoValidator;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _csManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _qctManager.GetActiveAsync();
            var model = new CategorySubtitleViewModel
            {
                QuarterCategoryTitles = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategorySubtitleViewModel model)
        {
            var result = _csvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<CategorySubtitleCreateDto>(model);
                var createResponse = await _csManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _qctManager.GetAllAsync();
            model.QuarterCategoryTitles = new SelectList(response.Data, "Id", "Title", model.QuarterCategoryTitleId);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _csManager.GetByIdAsync<CategorySubtitleUpdateDto>(id);
            var droplistResp = await _qctManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategorySubtitleUpdateDto dto)
        {
            var response = await _csManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _csManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

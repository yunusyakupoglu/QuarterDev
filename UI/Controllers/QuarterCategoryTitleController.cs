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
    public class QuarterCategoryTitleController : Controller
    {
        private readonly IQuarterCategoryTitleManager _qtlManager;
        private readonly IQuarterCategoryManager _qtManager;
        private readonly IValidator<QuarterCategoryTitleCreateDto> _qtlCreateDtoValidator;
        private readonly IValidator<QuarterCategoryTitlesViewModel> _qtlvmCreateDtoValidator;
        private readonly IMapper _mapper;

        public QuarterCategoryTitleController(IQuarterCategoryTitleManager qtlManager, IValidator<QuarterCategoryTitleCreateDto> qtlCreateDtoValidator, IMapper mapper, IValidator<QuarterCategoryTitlesViewModel> qtlvmCreateDtoValidator, IQuarterCategoryManager qtManager)
        {
            _qtlManager = qtlManager;
            _qtlCreateDtoValidator = qtlCreateDtoValidator;
            _mapper = mapper;
            _qtlvmCreateDtoValidator = qtlvmCreateDtoValidator;
            _qtManager = qtManager;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _qtlManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _qtManager.GetActiveAsync();
            var model = new QuarterCategoryTitlesViewModel
            {
                QuarterCategories = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuarterCategoryTitlesViewModel model)
        {
            var result = _qtlvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<QuarterCategoryTitleCreateDto>(model);
                var createResponse = await _qtlManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _qtManager.GetAllAsync();
            model.QuarterCategories = new SelectList(response.Data, "Id", "Title", model.QuarterCategoryId);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _qtlManager.GetByIdAsync<QuarterCategoryTitleUpdateDto>(id);
            var droplistResp = await _qtManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuarterCategoryTitleUpdateDto dto)
        {
            var response = await _qtlManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _qtlManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

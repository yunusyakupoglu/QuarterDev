using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
    [Authorize]
    public class QuarterCategoryController : Controller
    {
        private readonly IQuarterCategoryManager _qtManager;
        private readonly IValidator<QuarterCategoryCreateDto> _qtCreateDtoValidator;
        private readonly IMapper _mapper;

        public QuarterCategoryController(IQuarterCategoryManager qtManager, IValidator<QuarterCategoryCreateDto> qtCreateDtoValidator, IMapper mapper)
        {
            _qtManager = qtManager;
            _qtCreateDtoValidator = qtCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _qtManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _qtManager.GetByIdAsync<QuarterCategoryListDto>(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new QuarterCategoryCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuarterCategoryCreateDto model)
        {
            var result = _qtCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<QuarterCategoryCreateDto>(model);
                var createResponse = await _qtManager.CreateAsync(dto);
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
            var response = await _qtManager.GetByIdAsync<QuarterCategoryUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuarterCategoryUpdateDto dto)
        {
            var response = await _qtManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _qtManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

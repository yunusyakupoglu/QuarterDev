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
    public class CompanyServiceController : Controller
    {
        private readonly ICompanyServiceManager _csManager;
        private readonly IValidator<CompanyServiceCreateDto> _csCreateDtoValidator;
        private readonly IMapper _mapper;

        public CompanyServiceController(ICompanyServiceManager csManager, IValidator<CompanyServiceCreateDto> csCreateDtoValidator, IMapper mapper)
        {
            _csManager = csManager;
            _csCreateDtoValidator = csCreateDtoValidator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _csManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _csManager.GetByIdAsync<CompanyServiceListDto>(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CompanyServiceCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyServiceCreateDto model)
        {
            var result = _csCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<CompanyServiceCreateDto>(model);
                var createResponse = await _csManager.CreateAsync(dto);
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
            var response = await _csManager.GetByIdAsync<CompanyServiceUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyServiceUpdateDto dto)
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

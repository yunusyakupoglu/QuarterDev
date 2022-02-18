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
    public class CustomerController : Controller
	{
		private readonly ICustomerManager _customerManager;
		private readonly IValidator<CustomerCreateDto> _customerCreateDtoValidator;
		private readonly IMapper _mapper;

		public CustomerController(ICustomerManager customerManager, IValidator<CustomerCreateDto> customerCreateDtoValidator, IMapper mapper)
		{
			_customerManager = customerManager;
			_customerCreateDtoValidator = customerCreateDtoValidator;
			_mapper = mapper;
		}
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var response = await _customerManager.GetAllAsync();
            return this.ResponseView(response);
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _customerManager.GetByIdAsync<CustomerListDto>(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            var model = new CustomerCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto model)
        {
            var result = _customerCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<CustomerCreateDto>(model);
                var createResponse = await _customerManager.CreateAsync(dto);
                return this.ResponseRedirectActionWithController(createResponse, "Index","Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _customerManager.GetByIdAsync<CustomerUpdateDto>(id);
            return View(response.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(CustomerUpdateDto dto)
        {
            var response = await _customerManager.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _customerManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

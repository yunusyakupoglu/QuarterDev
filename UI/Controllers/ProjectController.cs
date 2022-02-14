using AutoMapper;
using BL.IServices;
using DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Controllers
{
	public class ProjectController : Controller
	{
		private readonly IProjectManager _projectManager;
		private readonly IValidator<ProjectCreateDto> _projectCreateDtoValidator;
		private readonly IValidator<ProjectUpdateDto> _projectUpdateDtoValidator;
		private readonly IMapper _mapper;

		public ProjectController(IProjectManager projectManager, IValidator<ProjectCreateDto> projectCreateDtoValidator, IValidator<ProjectUpdateDto> projectUpdateDtoValidator, IMapper mapper)
		{
			_projectManager = projectManager;
			_projectCreateDtoValidator = projectCreateDtoValidator;
			_projectUpdateDtoValidator = projectUpdateDtoValidator;
			_mapper = mapper;
		}


        public async Task<IActionResult> Index()
        {
            var response = await _projectManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            var model = new ProjectCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateDto model)
        {
            var result = _projectCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<ProjectCreateDto>(model);
                dto.ImagePath = _projectManager.UploadImage(dto.FileDoc);
                var createResponse = await _projectManager.CreateAsync(dto);
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
            var response = await _projectManager.GetByIdAsync<ProjectUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateDto dto)
        {
            var result = _projectUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _projectManager.DeleteImage(dto.ImagePath);
                    dto.ImagePath = _projectManager.UploadImage(dto.FileDoc);
                    var createResponse = await _projectManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _projectManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(dto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _projectManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

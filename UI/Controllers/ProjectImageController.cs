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
    public class ProjectImageController : Controller
    {
        private readonly IProjectImageManager _imgManager;
        private readonly IProjectManager _pManager;
        private readonly IValidator<ProjectImageCreateDto> _imgCreateDtoValidator;
        private readonly IValidator<ProjectImageUpdateDto> _imgUpdateDtoValidator;
        private readonly IValidator<ProjectImageViewModel> _imgvmCreateDtoValidator;
        private readonly IMapper _mapper;

		public ProjectImageController(IProjectImageManager imgManager, IProjectManager pManager, IValidator<ProjectImageCreateDto> imgCreateDtoValidator, IValidator<ProjectImageViewModel> imgvmCreateDtoValidator, IMapper mapper, IValidator<ProjectImageUpdateDto> imgUpdateDtoValidator)
		{
			_imgManager = imgManager;
			_pManager = pManager;
			_imgCreateDtoValidator = imgCreateDtoValidator;
			_imgvmCreateDtoValidator = imgvmCreateDtoValidator;
			_mapper = mapper;
			_imgUpdateDtoValidator = imgUpdateDtoValidator;
		}

		public async Task<IActionResult> Index()
        {
            var response = await _imgManager.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Create()
        {
            var response = await _pManager.GetActiveAsync();
            var model = new ProjectImageViewModel
            {
                Projects = new SelectList(response.Data, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectImageViewModel model)
        {
            var result = _imgvmCreateDtoValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<ProjectImageCreateDto>(model);
                dto.ImagePath = _imgManager.UploadImage(dto.FileDoc);
                var createResponse = await _imgManager.CreateAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _pManager.GetAllAsync();
            model.Projects = new SelectList(response.Data, "Id", "Title", model.ProjectId);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _imgManager.GetByIdAsync<ProjectImageUpdateDto>(id);
            var droplistResp = await _pManager.GetActiveAsync();
            ViewBag.mydroplist = new SelectList(droplistResp.Data, "Id", "Title");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectImageUpdateDto dto)
        {
            var result = _imgUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                if (dto.FileDoc != null)
                {
                    _imgManager.DeleteImage(dto.ImagePath);
                    dto.ImagePath = _imgManager.UploadImage(dto.FileDoc);
                    var createResponse = await _imgManager.UpdateAsync(dto);
                    return this.ResponseRedirectAction(createResponse, "Index");
                }
                else
                {
                    var createResponse = await _imgManager.UpdateAsync(dto);
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
            var response = await _imgManager.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "Index");
        }
    }
}

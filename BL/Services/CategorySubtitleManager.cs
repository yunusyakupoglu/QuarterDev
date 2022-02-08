using AutoMapper;
using BL.IServices;
using Common;
using DAL.UnitOfWork;
using DTOs;
using FluentValidation;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CategorySubtitleManager : Service<CategorySubtitleCreateDto, CategorySubtitleUpdateDto, CategorySubtitleListDto, ObjCategorySubtitle>, ICategorySubtitleManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategorySubtitleManager(IMapper mapper, IValidator<CategorySubtitleCreateDto> createDtoValidator, IValidator<CategorySubtitleUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<List<CategorySubtitleListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjCategorySubtitle>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<CategorySubtitleListDto>>(data);
            return new Response<List<CategorySubtitleListDto>>(ResponseType.Success, dto);
        }
    }
}

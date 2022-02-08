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
    public class QuarterCategoryManager : Service<QuarterCategoryCreateDto, QuarterCategoryUpdateDto, QuarterCategoryListDto, ObjQuarterCategory>, IQuarterCategoryManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuarterCategoryManager(IMapper mapper, IValidator<QuarterCategoryCreateDto> createDtoValidator, IValidator<QuarterCategoryUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse<List<QuarterCategoryListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjQuarterCategory>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<QuarterCategoryListDto>>(data);
            return new Response<List<QuarterCategoryListDto>>(ResponseType.Success, dto);
        }
    }
}

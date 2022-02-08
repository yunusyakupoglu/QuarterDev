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
    public class QuarterCategoryTitleManager : Service<QuarterCategoryTitleCreateDto, QuarterCategoryTitleUpdateDto, QuarterCategoryTitleListDto, ObjQuarterCategoryTitle>, IQuarterCategoryTitleManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public QuarterCategoryTitleManager(IMapper mapper, IValidator<QuarterCategoryTitleCreateDto> createDtoValidator, IValidator<QuarterCategoryTitleUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse<List<QuarterCategoryTitleListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjQuarterCategoryTitle>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<QuarterCategoryTitleListDto>>(data);
            return new Response<List<QuarterCategoryTitleListDto>>(ResponseType.Success, dto);
        }
    }
}

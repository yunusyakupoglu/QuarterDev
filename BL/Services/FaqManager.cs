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
    public class FaqManager : Service<FaqCreateDto, FaqUpdateDto, FaqListDto, ObjFaq>, IFaqManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public FaqManager(IMapper mapper, IValidator<FaqCreateDto> createDtoValidator, IValidator<FaqUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse<List<FaqListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjFaq>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<FaqListDto>>(data);
            return new Response<List<FaqListDto>>(ResponseType.Success, dto);
        }
    }
}

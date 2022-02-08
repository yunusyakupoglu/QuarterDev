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
    public class AboutUsManager : Service<AboutUsCreateDto, AboutUsUpdateDto, AboutUsListDto, ObjAboutUs>, IAboutUsManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AboutUsManager(IMapper mapper, IValidator<AboutUsCreateDto> createDtoValidator, IValidator<AboutUsUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IValidator<AboutUsCreateDto> createDtovalidator) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<List<AboutUsListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjAboutUs>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<AboutUsListDto>>(data);
            return new Response<List<AboutUsListDto>>(ResponseType.Success, dto);
        }

    }
}

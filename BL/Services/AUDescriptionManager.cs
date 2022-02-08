using AutoMapper;
using BL.Extensions;
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
    public class AUDescriptionManager : Service<AUDescriptionCreateDto, AUDescriptionUpdateDto, AUDescriptionListDto, ObjAUDescription>, IAUDescriptionManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AUDescriptionCreateDto> _AUDescriptionCreateDtovalidator;
        public AUDescriptionManager(IMapper mapper, IValidator<AUDescriptionCreateDto> createDtoValidator, IValidator<AUDescriptionUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IValidator<AUDescriptionCreateDto> aUDescriptionCreateDtovalidator) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _AUDescriptionCreateDtovalidator = aUDescriptionCreateDtovalidator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse<List<AUDescriptionListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjAUDescription>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<AUDescriptionListDto>>(data);
            return new Response<List<AUDescriptionListDto>>(ResponseType.Success, dto);
        }

        //public async Task<IResponse<AUDescriptionCreateDto>> CreateWithAboutUsAsync(AUDescriptionCreateDto dto, int aboutUsId)
        //{
        //    var validationResult = _AUDescriptionCreateDtovalidator.Validate(dto);
        //    if (validationResult.IsValid)
        //    {
        //        var description = _mapper.Map<ObjAUDescription>(dto);
        
        //        description.ObjAboutUs.Id = aboutUsId;
        //        await _unitOfWork.GetRepository<ObjAUDescription>().CreateAsync(description);
        //    }
        //    return new Response<AUDescriptionCreateDto>(dto,validationResult.ConvertToCustomValidationError());
        //}
    }
}

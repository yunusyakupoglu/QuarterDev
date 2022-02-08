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
    public class SubtitleDescriptionManager : Service<SubtitleDescriptionCreateDto, SubtitleDescriptionUpdateDto, SubtitleDescriptionListDto, ObjSubtitleDescription>, ISubtitleDescriptionManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubtitleDescriptionManager(IMapper mapper, IValidator<SubtitleDescriptionCreateDto> createDtoValidator, IValidator<SubtitleDescriptionUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<List<SubtitleDescriptionListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjSubtitleDescription>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<SubtitleDescriptionListDto>>(data);
            return new Response<List<SubtitleDescriptionListDto>>(ResponseType.Success, dto);
        }
    }
}

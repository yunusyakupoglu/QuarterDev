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
    public class SubtitleItemManager : Service<SubtitleItemCreateDto, SubtitleItemUpdateDto, SubtitleItemListDto, ObjSubtitleItem>, ISubtitleItemManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubtitleItemManager(IMapper mapper, IValidator<SubtitleItemCreateDto> createDtoValidator, IValidator<SubtitleItemUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<List<SubtitleItemListDto>>> GetActiveAsync()
        {
            var data = await _unitOfWork.GetRepository<ObjSubtitleItem>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<SubtitleItemListDto>>(data);
            return new Response<List<SubtitleItemListDto>>(ResponseType.Success, dto);
        }
    }
}

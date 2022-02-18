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
	public class CustomerManager : Service<CustomerCreateDto, CustomerUpdateDto, CustomerListDto, ObjCustomer>, ICustomerManager
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public CustomerManager(IMapper mapper, IValidator<CustomerCreateDto> createDtoValidator, IValidator<CustomerUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IResponse<List<CustomerListDto>>> GetActiveAsync()
		{
			var data = await _unitOfWork.GetRepository<ObjCustomer>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.ASC);
			var dto = _mapper.Map<List<CustomerListDto>>(data);
			return new Response<List<CustomerListDto>>(ResponseType.Success, dto);
		}
	}
}

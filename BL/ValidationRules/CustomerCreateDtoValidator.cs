using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
	public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
	{
		public CustomerCreateDtoValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
			RuleFor(x => x.CustomerSurName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
			RuleFor(x => x.CustomerMail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz.");
			RuleFor(x => x.CustomerPhone).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
			RuleFor(x => x.ProductType).NotEmpty().WithMessage("Lütfen bir ürün seçiniz.");
		}
	}
}

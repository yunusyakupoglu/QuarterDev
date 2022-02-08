using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AboutUsUpdateDtoValidator : AbstractValidator<AboutUsUpdateDto>
    {
        public AboutUsUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}

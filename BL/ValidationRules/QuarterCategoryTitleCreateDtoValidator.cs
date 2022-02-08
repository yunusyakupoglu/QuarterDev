using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class QuarterCategoryTitleCreateDtoValidator : AbstractValidator<QuarterCategoryTitleCreateDto>
    {
        public QuarterCategoryTitleCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

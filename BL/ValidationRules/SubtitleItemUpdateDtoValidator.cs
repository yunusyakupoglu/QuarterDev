using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class SubtitleItemUpdateDtoValidator : AbstractValidator<SubtitleItemUpdateDto>
    {
        public SubtitleItemUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}

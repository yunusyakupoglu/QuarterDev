﻿using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class CategorySubtitleUpdateDtoValidator : AbstractValidator<CategorySubtitleUpdateDto>
    {
        public CategorySubtitleUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}

using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
	public class ProjectUpdateDtoValidator : AbstractValidator<ProjectUpdateDto>
	{
		public ProjectUpdateDtoValidator()
		{
			RuleFor(x=>x.Id).NotEmpty();
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.BrandName).NotEmpty();
			RuleFor(x => x.ProjectType).NotEmpty();
			RuleFor(x => x.Description).NotEmpty();
		}
	}
}

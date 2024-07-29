using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
	public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
	{
		public CreateCompanyCommandValidator()
		{
			RuleFor(p=>p.DatabaseName).NotNull().WithMessage("Database bilgisi yazılmalıdır.")
				                      .NotEmpty().WithMessage("Database bilgisi yazılmalıdır.");
			RuleFor(p => p.ServerName).NotNull().WithMessage("Server bilgisi yaılmalıdır.")
									.NotEmpty().WithMessage("Server bilgisi yazılmalıdır.");
			RuleFor(p => p.Name).NotNull().WithMessage("Şirket bilgisi yazılmalıdır.")
							  .NotEmpty().WithMessage("Şirket bilgisi yazılmalıdır.");
		}
	}
}

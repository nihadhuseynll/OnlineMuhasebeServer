using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public sealed class CreateUcafCommandValidator : AbstractValidator<CreateUCAFCommand>
	{
		public CreateUcafCommandValidator()
		{
			RuleFor(p => p.Code).NotNull().WithMessage("Hesap planı kodu boş olamaz.")
							    .NotEmpty().WithMessage("Hesap planı kodu boş olamaz.");

			RuleFor(p => p.Name).NotNull().WithMessage("Hesap planı adı boş olamaz.")
							    .NotEmpty().WithMessage("Hesap planı adı boş olamaz.");

			RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz.")
								     .NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");

			RuleFor(p => p.Type).NotNull().WithMessage("Hesap planı tipi boş olamaz.")
							    .NotEmpty().WithMessage("Hesap planı tipi boş olamaz.")
							    .MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır.");
		}
	}
}

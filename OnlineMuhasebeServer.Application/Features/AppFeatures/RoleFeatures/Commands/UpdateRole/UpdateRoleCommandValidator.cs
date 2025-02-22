﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>	
	{
		public UpdateRoleCommandValidator()
		{
			RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz.")
				              .NotEmpty().WithMessage("Id bilgisi boş olamaz.");

			RuleFor(p => p.Code).NotNull().WithMessage("Role kodu boş olamaz.")
			                	.NotEmpty().WithMessage("Role kodu boş olamaz.");

			RuleFor(p => p.Name).NotNull().WithMessage("Role adı boş olamaz.")
								.NotEmpty().WithMessage("Role adı boş olamaz.");
		}
	}
}

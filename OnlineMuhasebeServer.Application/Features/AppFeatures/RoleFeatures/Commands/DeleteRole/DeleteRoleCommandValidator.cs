using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
	public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
	{
		public DeleteRoleCommandValidator()
		{
			RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz.")
							  .NotEmpty().WithMessage("Id bilgisi boş olamaz.");
		}
	}
}

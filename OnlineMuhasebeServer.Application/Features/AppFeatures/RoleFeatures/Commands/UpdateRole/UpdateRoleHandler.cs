using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
	{
		private readonly IRoleService _roleService;

		public UpdateRoleHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
		{
			AppRole role = await _roleService.GetByIdAsync(request.Id);
			if (role == null) throw new Exception("Role bulunamadı!");

			if(role.Code != request.Code)
			{
				AppRole checkCode = await _roleService.GetByCodeAsync(request.Code);
				if (checkCode != null) throw new Exception("Bu kod daha önce kaydedilmiş!");
			}

			role.Code = request.Code;
			role.Name = request.Name;
			await _roleService.UpdateAsync(role);
			return new();
		}
	}
}

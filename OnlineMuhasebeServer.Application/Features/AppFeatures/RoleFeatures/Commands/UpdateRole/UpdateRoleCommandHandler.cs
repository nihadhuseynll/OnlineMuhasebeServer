﻿using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
	public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
	{
		private readonly IRoleService _roleService;

		public UpdateRoleCommandHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
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

using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
	public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
	{
		private readonly IRoleService _roleService;

		public DeleteRoleHandler(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
		{
			AppRole role = await _roleService.GetByIdAsync(request.Id);
			if (role == null) throw new Exception("Role Bulunamdı !");

			await _roleService.DeleteAsync(role);
			return new();
		}
	}
}

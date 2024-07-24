using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
	public interface IRoleService
	{
		Task AddAsync(CreateRoleRequest request);
		Task UpdateAsync(AppRole appRole);
		Task DeleteAsync(AppRole appRole);
		Task<IList<AppRole>> GetAllRolesAsync();
		Task<AppRole> GetByIdAsync(string id);
		Task<AppRole> GetByCodeAsync(string code);
	}
}

using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
	public sealed class CreateRoleCommandUnitTest
	{
		private readonly Mock<IRoleService> _roleService;

		public CreateRoleCommandUnitTest()
		{
			_roleService = new();
		}
		[Fact]
		public async Task AppRoleShouldBeNull()
		{
			AppRole appRole = await _roleService.Object.GetByCodeAsync("UCAF.Setting");
			appRole.ShouldBeNull();
		}
		[Fact]
		public async Task CreateRoleCommandResponseShoouldNotBeNull()
		{
			var command = new CreateRoleCommand(
				Code : "UCAF.Setting",
				Name : "Hesap planı Setting işlemi."
				);

			var handler = new CreateRoleCommandHandler(_roleService.Object);
			CreateRoleCommandResponse response = await handler.Handle(command, default);
			response.ShouldNotBeNull();
			response.Message.ShouldNotBeEmpty();

		}

	}
}

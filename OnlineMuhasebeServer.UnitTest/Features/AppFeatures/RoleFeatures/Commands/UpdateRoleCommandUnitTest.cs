using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Org.BouncyCastle.Security;
using Shouldly;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
	public sealed class UpdateRoleCommandUnitTest
	{
		private readonly Mock<IRoleService> _roleServiceMock;

		public UpdateRoleCommandUnitTest()
		{
			_roleServiceMock = new();
		}
		[Fact]
		public async Task AppRoleShouldNotBeNull()
		{
			_ = _roleServiceMock.Setup(
				x=>x.GetByIdAsync(It.IsAny<string>()))
				.ReturnsAsync(new AppRole());
		}
		[Fact]
		public async Task AppRoleCodeShouldBeUnique()
		{
			AppRole checkCode = await _roleServiceMock.Object.GetByCodeAsync("Create.Ucaf");
			checkCode.ShouldBeNull();
		}
		[Fact]
		public async Task UpdateRoleCommandResponseShouldNotBeNull()
		{
			_roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
	            .ReturnsAsync(new AppRole { Id = "1e44dc4a-27e4-422d-81bd-2b4e2d5d178a", Code = "OldCode", Name = "OldName" });

			_roleServiceMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>()))
				.ReturnsAsync((AppRole)null!);

			_roleServiceMock.Setup(x => x.UpdateAsync(It.IsAny<AppRole>()))
				.Returns(Task.CompletedTask);

			var command = new UpdateRoleCommand(
				Id: "1e44dc4a-27e4-422d-81bd-2b4e2d5d178a",
				Code: "UCAF.Create",
				Name: "Hesap Planı Kayıt Ekleme"
				);

			var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);
			UpdateRoleCommandResponse response = await handler.Handle(command, default);
			response.ShouldNotBeNull();
			response.Message.ShouldNotBeEmpty();
		}

	}
}

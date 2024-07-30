using Moq;
using NPOI.SS.Formula.Functions;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
	public sealed class DeleteRoleCommandUnitTest
	{
		private readonly Mock<IRoleService> _roleServiceMock;

		public DeleteRoleCommandUnitTest()
		{
			_roleServiceMock = new();
		}
		[Fact]
		public async Task AppRoleShouldNotBeNull()
		{
			_roleServiceMock.Setup(
				x => x.GetByIdAsync(It.IsAny<string>()))
				.ReturnsAsync(new AppRole());
		}
		[Fact]
		public async Task DeleteRoleCommandResponseShouldNotBeNull()
		{
			_roleServiceMock.Setup(
				x => x.GetByIdAsync(It.IsAny<string>()))
				.ReturnsAsync(new AppRole());

			var command = new DeleteRoleCommand(
				Id : "45276d75-13d4-4e7c-b2f3-1cdc39636dd4"
				);

			var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);
			DeleteRoleCommandResponse response = await handler.Handle(command, default);
			response.ShouldNotBeNull();
			response.Message.ShouldNotBeEmpty();
		}
	}
}

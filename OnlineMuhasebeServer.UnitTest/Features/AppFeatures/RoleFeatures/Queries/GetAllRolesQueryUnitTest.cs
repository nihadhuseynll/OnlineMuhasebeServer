using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Queries
{
	public sealed class GetAllRolesQueryUnitTest
	{
		private readonly Mock<IRoleService> _roleServiceMock;

		public GetAllRolesQueryUnitTest()
		{
			_roleServiceMock = new();
		}
		[Fact]
		public async Task GetAllRolesQueryResponseShouldNotBeNull()
		{
			_roleServiceMock.Setup(
				x => x.GetAllRolesAsync())
				.ReturnsAsync(new List<AppRole>());
		}
	}
}

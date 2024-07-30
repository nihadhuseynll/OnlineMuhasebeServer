using Moq;
using NPOI.OpenXmlFormats.Wordprocessing;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.Commands
{
	public sealed class CreateUCAFCommandUnitTest
	{
		private readonly Mock<IUCAFService> _ucafService;

		public CreateUCAFCommandUnitTest()
		{
			_ucafService = new();
		}
		[Fact]
		public async Task UcafShouldBeNull()
		{
			_ucafService.Setup(
				x => x.GetByCode(It.IsAny<string>()))
				.ReturnsAsync((UniformChartOfAccount)null!);
		}
		[Fact]
		public async Task CreateUCAFCommandResponseShouldNotBeNull()
		{
			var command = new CreateUCAFCommand(
				Code : "100.111",
				Name : "Cache",
				Type : "M",
				CompanyId : "1e44dc4a-27e4-422d-81bd-2b4e2d5d178kl"
				);
			var handler = new CreateUCAFCommandHandler(_ucafService.Object);
			CreateUCAFCommandResponse response = await handler.Handle(command, default);
			response.ShouldNotBeNull();
			response.Message.ShouldNotBeEmpty();
		}
	}
}

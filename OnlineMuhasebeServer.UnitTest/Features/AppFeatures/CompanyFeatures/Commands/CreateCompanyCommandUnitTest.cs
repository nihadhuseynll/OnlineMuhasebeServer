using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using Xunit;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.CompanyFeatures.Commands
{
	public class CreateCompanyCommandUnitTest
	{
		private readonly Mock<ICompanyService> _companyService;

		public CreateCompanyCommandUnitTest()
		{
			_companyService = new();
		}
		[Fact]
		public async Task CompanyShouldBeNull()
		{
			Company company = (await _companyService.Object.GetCompanyByName("Saydam Ltd"))!;
			company.ShouldBeNull();
		}
		[Fact]
		public async Task CreateCompanyCommandResponseShoudNotBeNull()
		{
			var command = new CreateCompanyCommand(
				Name : "Saydam Ltd",
				ServerName : "localhost",
				DatabaseName : "SaydamDb",
				UserId : "",
				Password : ""
				);

			var handler = new CreateCompanyCommandHandler(_companyService.Object);

			CreateCompanyCommandResponse response = await handler.Handle(command, default);
			response.ShouldNotBeNull();
			response.Message.ShouldNotBeEmpty();
		}
	}
}

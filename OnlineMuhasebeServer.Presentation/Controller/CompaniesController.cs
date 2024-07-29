using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
	public class CompaniesController : ApiController
	{
		public CompaniesController(IMediator mediator) : base(mediator)
		{
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
		{
			CreateCompanyCommandResponse response = await _mediator.Send(request,cancellationToken);
			return Ok(response);
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> MigrateCompanyDatabases()
		{
			MigrateCompanyDatabasesCommand request = new();
			MigrateCompanyDatabasesCommandResponse response = await _mediator.Send(request);
			return Ok(response);
		}
		[HttpGet]
		public async Task<IActionResult> CheckCancellationToken(CancellationToken cancellationToken)
		{
			try
			{
				await Task.Delay(10000,cancellationToken);
				Console.WriteLine("Cancellation token iptal edildi.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cancellation token-de problem yok.");
			}
			return NoContent();
		}
	}
}

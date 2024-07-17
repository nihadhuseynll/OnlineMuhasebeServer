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
		public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
		{
			CreateCompanyResponse response = await _mediator.Send(request);
			return Ok(response);
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> MigrateCompanyDatabases()
		{
			MigrateCompanyDatabasesRequest request = new();
			MigrateCompanyDatabasesResponse response = await _mediator.Send(request);
			return Ok(response);
		}
	}
}

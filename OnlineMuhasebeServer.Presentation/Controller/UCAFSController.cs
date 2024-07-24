using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Presentation.Controller
{
	public sealed class UCAFSController : ApiController
	{
		public UCAFSController(IMediator mediator) : base(mediator)
		{
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request)
		{
			CreateUCAFCommandResponse response = await _mediator.Send(request);
			return Ok(response);
		}
	}
}

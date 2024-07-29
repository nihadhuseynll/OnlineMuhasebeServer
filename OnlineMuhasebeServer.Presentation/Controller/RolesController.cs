﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller
{
	public class RolesController : ApiController
	{
		public RolesController(IMediator mediator) : base(mediator)
		{
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> CreateRole(CreateRoleCommand request, CancellationToken cancellationToken)
		{
			CreateRoleCommandResponse response = await _mediator.Send(request,cancellationToken);
			return Ok(response);	
		}
		[HttpGet("[action]")]
		public async Task<IActionResult> GetAllRoles()
		{
			GetAllRolesQuery request = new GetAllRolesQuery();
			GetAllRolesQueryResponse response = await _mediator.Send(request);
			return Ok(response);
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> UpdateRoles(UpdateRoleCommand request)
		{
			UpdateRoleCommandResponse response = await _mediator.Send(request);	
			return Ok(response);
		}
		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> DeleteRole(string id)
		{
			DeleteRoleCommand request = new DeleteRoleCommand(id);
			DeleteRoleCommandResponse response = await _mediator.Send(request);	
			return Ok(response);
		}
	}
}

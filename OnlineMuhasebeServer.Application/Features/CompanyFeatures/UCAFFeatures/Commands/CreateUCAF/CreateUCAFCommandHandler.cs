using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
	{
		private readonly IUCAFService _ucafService;

		public CreateUCAFCommandHandler(IUCAFService ucafService)
		{
			_ucafService = ucafService;
		}

		public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
		{

			UniformChartOfAccount ucaf = await _ucafService.GetByCode(request.Code);
			if (ucaf != null) throw new Exception("Bu hesap planı kodu daha önce tanımlanmış. ");

			await _ucafService.CreateUCAFAsync(request,cancellationToken);
			return new();
		}
	}
}

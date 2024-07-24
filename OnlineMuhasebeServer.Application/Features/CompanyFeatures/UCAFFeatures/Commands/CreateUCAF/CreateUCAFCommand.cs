using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public sealed record CreateUCAFCommand(
		string Code,
		string Name,
		string Type,
		string CompanyId
		) : ICommand<CreateUCAFCommandResponse>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public sealed record CreateUCAFCommandResponse(
		string Message = "Hesap Planı Kaydı Başarıyla Tamamlandı."
		);
}

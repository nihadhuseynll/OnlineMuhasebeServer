using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases
{
	public sealed class MigrateCompanyDatabasesResponse
	{
		public string Message { get; set; } = "Şirketlerin DataBase Bilgileri Migrate Edildi.";
	}
}

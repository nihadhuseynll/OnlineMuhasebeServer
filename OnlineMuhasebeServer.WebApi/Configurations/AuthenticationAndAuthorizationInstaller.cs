using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineMuhasebeServer.Infrastructure.Authentication;
using OnlineMuhasebeServer.WebApi.OptionsSetup;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
	public class AuthenticationAndAuthorizationInstaller : IServiceInstaller
	{
		public void Install(IServiceCollection services, IConfiguration configuration)
		{
			services.ConfigureOptions<JwtOptionsSetup>();
			services.ConfigureOptions<JwtBearerOptionsSetup>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer();
		}
	}
}

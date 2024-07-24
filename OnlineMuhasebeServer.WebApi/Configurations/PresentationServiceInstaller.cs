using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Presentation;
using OnlineMuhasebeServer.WebApi.Middleware;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
	public class PresentationServiceInstaller : IServiceInstaller
	{
		public void Install(IServiceCollection services, IConfiguration configuration)
		{

			services.AddScoped<ExceptionMiddleware>();
			services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(setup =>
			{
				var jwtSecurityScheme = new OpenApiSecurityScheme
				{
					BearerFormat = "JWT",
					Name = "JWT Authentication",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
				setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                   	{
                   		{jwtSecurityScheme,Array.Empty<string>() }
                   	});
			});
		}
	}
}

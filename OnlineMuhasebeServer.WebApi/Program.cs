using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using(var scoped = app.Services.CreateScope())
{
	var usermanager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
	if (!usermanager.Users.Any())
	{
		usermanager.CreateAsync(new AppUser
		{
			UserName = "HNihad",
			Email = "huseynlinihad4400@gmail.com",
			Id = Guid.NewGuid().ToString(),	
			NameLastName = "Nihad Hüseynli"
		},"Password12*").Wait();
	}
}

app.Run();

using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Context;
using OnlineMuhasebeServer.Persistance.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Services.AppServices;
using OnlineMuhasebeServer.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
                                         options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();	
builder.Services.AddScoped<IUCAFCommandRepository,UCAFCommandRepository>();	
builder.Services.AddScoped<IUCAFQueryRepository,UCAFQueryRepository>();	

builder.Services.AddMediatR(typeof
	(OnlineMuhasebeServer.Application.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof
	(OnlineMuhasebeServer.Persistance.AssemblyReference).Assembly);

builder.Services.AddControllers().AddApplicationPart(typeof(OnlineMuhasebeServer.Presentation.AssemblyReference).Assembly);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
	var jwtSecurityScheme = new OpenApiSecurityScheme
	{
		BearerFormat="JWT",
		Name="JWT Authentication",
		In=ParameterLocation.Header,
		Type=SecuritySchemeType.Http,
		Scheme=JwtBearerDefaults.AuthenticationScheme,
		Description="Put **_ONLY_** your JWT Bearer token on textbox below!",

		Reference= new OpenApiReference
		{
			Id=JwtBearerDefaults.AuthenticationScheme,
			Type=ReferenceType.SecurityScheme
		}
	};

	setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
	setup.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{jwtSecurityScheme,Array.Empty<string>() }
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

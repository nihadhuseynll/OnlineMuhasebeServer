using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
	public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
	{
		private readonly IJwtProvider _jwtProvider;
		private readonly UserManager<AppUser> _userManager;

		public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
		{
			_jwtProvider = jwtProvider;
			_userManager = userManager;
		}

		public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
		{
			AppUser user = await _userManager.Users.Where
				(p=>p.Email == request.EmailOrUserName||
				 p.UserName == request.EmailOrUserName)
				.FirstOrDefaultAsync();
			if (user == null) throw new Exception("Kullanıcı bulunamadı!");

			var checkUser = await _userManager.CheckPasswordAsync(user,request.Password);
			if (!checkUser) throw new Exception("Şifreniz Yanlış!");

			List<string> roles = new List<string>();

			LoginResponse response = new LoginResponse()
			{
				NameLastName = user.NameLastName,
				Email = user.Email,
				UserId = user.Id,
				Token =await  _jwtProvider.CreateTokenAsync(user,roles)
			};

			return response;	
		}
	}
}

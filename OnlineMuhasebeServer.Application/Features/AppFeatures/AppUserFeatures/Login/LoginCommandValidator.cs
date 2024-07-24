using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
	public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
	{
		public LoginCommandValidator()
		{
			RuleFor(p=>p.EmailOrUserName).NotNull().WithMessage("Mail ya da kullanıcı adı yazmalısınız !")
				                         .NotEmpty().WithMessage("Mail ya da kullanıcı adı yazmalısınız !");
			RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz !")
									.NotEmpty().WithMessage("Şifre boş olamaz !")
									.MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır !")
									.Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir !")
									.Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir !")
									.Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir !")
									.Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir !");
		}
	}
}

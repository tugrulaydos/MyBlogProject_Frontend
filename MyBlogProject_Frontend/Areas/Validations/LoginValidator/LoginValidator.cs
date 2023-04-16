using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Login;

namespace MyBlogProject_Frontend.Areas.Validations.LoginValidator
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(e => e.Email).NotEmpty().WithMessage("Email Boş Geçilemez")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Lütfen Geçerli Bir Email Formatı Giriniz");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Boş Bırakılamaz");

            RuleFor(p => p.Password).Length(1, 8).WithMessage("1 ile 8 arasında olmalıdır.");            


        }

    }
}

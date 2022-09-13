using Core.Entities.DTOs;
using FluentValidation;

namespace Service.Validators.AuthValidators;

public class LoginValidator:AbstractValidator<UserLoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
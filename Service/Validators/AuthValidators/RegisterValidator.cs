using Core.Entities.DTOs;
using FluentValidation;

namespace Service.Validators.AuthValidators;

public class RegisterValidator:AbstractValidator<UserRegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2);
    }
}
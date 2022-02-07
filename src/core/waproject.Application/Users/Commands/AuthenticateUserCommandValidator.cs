using FluentValidation;
using FluentValidation.Results;

namespace waproject.Application.Users.Commands
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Password).NotEmpty();
        }
    }
}

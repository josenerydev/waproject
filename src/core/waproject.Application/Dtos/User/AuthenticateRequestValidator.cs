using FluentValidation;
using FluentValidation.Results;

namespace waproject.Application.Dtos.User
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Password).NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<AuthenticateRequest> context)
        {
            return (context.InstanceToValidate == null)
                ? new ValidationResult(new[] { new ValidationFailure("AuthenticateRequest", "AuthenticateRequest cannot be null") })
                : base.Validate(context);
        }
    }
}

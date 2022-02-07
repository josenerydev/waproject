using FluentValidation;

namespace waproject.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty();

            RuleFor(v => v.Description)
                .NotEmpty();

            RuleFor(v => v.Price)
                .NotEmpty();
        }
    }
}

using FluentValidation;

namespace Ecommerce.Application.Features.Product.Command.AddProductCommand
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {

        public AddProductValidator()
        {
            // Name is required and should have a maximum length of 100 characters
            RuleFor(x => x.AddProductDto.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .MaximumLength(100)
                .WithMessage("Product name cannot exceed 100 characters.");

            // Description can be null, but if provided, it should not exceed 500 characters
            RuleFor(x => x.AddProductDto.Description)
                .MaximumLength(500)
                .WithMessage("Product description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.AddProductDto.Description));

            // Price should be greater than 0
            RuleFor(x => x.AddProductDto.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

            // QuantityInStock should be at least 0
            RuleFor(x => x.AddProductDto.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity in stock cannot be negative.");

            // Status is required and must be one of the predefined values (e.g., "Available", "OutOfStock", etc.)
            RuleFor(x => x.AddProductDto.Status)
                .NotEmpty()
                .WithMessage("Status is required.")
                .WithMessage("Invalid status. Must be one of: Available, OutOfStock, Discontinued.");

            // CategoryId should be a positive integer
            RuleFor(x => x.AddProductDto.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be a positive integer.");

            // TimeAdded must be a valid date and cannot be a future date
            RuleFor(x => x.AddProductDto.TimeAdded)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Time added cannot be in the future.");

        }

    }
}

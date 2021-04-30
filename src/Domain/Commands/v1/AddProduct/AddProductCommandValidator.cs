using FluentValidation;
using LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity;
using LiquidCRUDExample.Domain.Infrastructure.Repositories.Entities;

namespace LiquidCRUDExample.Domain.Commands.v1.AddProduct
{
    public class AddProductCommandValidator : AddGenericEntityCommandValidator<Product, int>
    {
        public AddProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
        }
    }
}

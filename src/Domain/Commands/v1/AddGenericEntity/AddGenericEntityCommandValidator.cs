using FluentValidation;
using FluentValidation.Results;
using Liquid.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity
{
    public abstract class AddGenericEntityCommandValidator<TEntity, TIdentifier> : AbstractValidator<TEntity>, IValidator<AddGenericEntityCommand<TEntity, TIdentifier>> where TEntity : RepositoryEntity<TIdentifier>
    {
        public ValidationResult Validate(AddGenericEntityCommand<TEntity, TIdentifier> instance)
        {
            return Validate(instance?.Data);
        }

        public async Task<ValidationResult> ValidateAsync(AddGenericEntityCommand<TEntity, TIdentifier> instance, CancellationToken cancellation = default)
        {
            return await ValidateAsync(instance?.Data, cancellation);
        }
    }
}

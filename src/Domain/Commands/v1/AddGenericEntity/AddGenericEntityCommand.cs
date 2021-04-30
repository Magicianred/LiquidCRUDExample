using Liquid.Repository;
using MediatR;

namespace LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity
{
    public class AddGenericEntityCommand<TEntity, TIdentifier> : IRequest<AddGenericEntityCommandResponse<TIdentifier>> where TEntity : RepositoryEntity<TIdentifier>
    {
        public TEntity Data { get; set; }

        public AddGenericEntityCommand(TEntity data)
        {
            Data = data;
        }
    }
}

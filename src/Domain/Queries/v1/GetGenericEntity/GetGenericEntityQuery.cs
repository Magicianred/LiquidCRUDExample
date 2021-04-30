using Liquid.Repository;
using MediatR;

namespace LiquidCRUDExample.Domain.Queries.v1.GetGenericEntity
{
    public class GetGenericEntityQuery<TEntity, TIdentifier> : IRequest<GetGenericEntityQueryResponse<TEntity>> where TEntity : RepositoryEntity<TIdentifier>
    {
        public TIdentifier Id { get; set; }

        public GetGenericEntityQuery(TIdentifier id)
        {
            Id = id;
        }
    }
}

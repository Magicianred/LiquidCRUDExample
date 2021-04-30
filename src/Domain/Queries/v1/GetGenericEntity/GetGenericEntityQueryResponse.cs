using System.Collections.Generic;

namespace LiquidCRUDExample.Domain.Queries.v1.GetGenericEntity
{
    public class GetGenericEntityQueryResponse<TEntity>
    {
        public IEnumerable<TEntity> Data { get; set; }

        public GetGenericEntityQueryResponse(IEnumerable<TEntity> data)
        {
            Data = data;
        }
    }
}

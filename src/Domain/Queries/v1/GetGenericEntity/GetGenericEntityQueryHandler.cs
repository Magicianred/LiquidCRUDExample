using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using Liquid.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LiquidCRUDExample.Domain.Queries.v1.GetGenericEntity

{
    public class GetGenericEntityQueryHandler<TEntity, TIdentifier> : RequestHandlerBase, IRequestHandler<GetGenericEntityQuery<TEntity, TIdentifier>, GetGenericEntityQueryResponse<TEntity>> where TEntity : RepositoryEntity<TIdentifier>
    {
        public readonly ILogger<GetGenericEntityQueryHandler<TEntity, TIdentifier>> _logger;

        public GetGenericEntityQueryHandler(
            IMediator mediatorService,
            ILightContext contextService,
            ILightTelemetry telemetryService,
            IMapper mapperService,
            ILogger<GetGenericEntityQueryHandler<TEntity, TIdentifier>> logger) : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _logger = logger;
        }

        public async Task<GetGenericEntityQueryResponse<TEntity>> Handle(GetGenericEntityQuery<TEntity, TIdentifier> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetGenericEntityQuery: {data}", request.Id);
            return new GetGenericEntityQueryResponse<TEntity>(null);
        }
    }
}

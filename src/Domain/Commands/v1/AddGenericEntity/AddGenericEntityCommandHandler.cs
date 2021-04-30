using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using Liquid.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity

{
    public class AddGenericEntityCommandHandler<TEntity, TIdentifier> : RequestHandlerBase, IRequestHandler<AddGenericEntityCommand<TEntity, TIdentifier>, AddGenericEntityCommandResponse<TIdentifier>> where TEntity : RepositoryEntity<TIdentifier>
    {
        public readonly ILogger<AddGenericEntityCommandHandler<TEntity, TIdentifier>> _logger;

        public AddGenericEntityCommandHandler(
            IMediator mediatorService,
            ILightContext contextService,
            ILightTelemetry telemetryService,
            IMapper mapperService,
            ILogger<AddGenericEntityCommandHandler<TEntity, TIdentifier>> logger) : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _logger = logger;
        }

        public async Task<AddGenericEntityCommandResponse<TIdentifier>> Handle(AddGenericEntityCommand<TEntity, TIdentifier> request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AddGenericEntityCommand: {data}", request.Data);
            return new AddGenericEntityCommandResponse<TIdentifier>(request.Data.Id);
        }
    }
}

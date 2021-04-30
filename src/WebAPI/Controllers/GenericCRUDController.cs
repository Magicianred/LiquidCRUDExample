using Liquid.Core.Context;
using Liquid.Core.Localization;
using Liquid.Core.Telemetry;
using Liquid.Repository;
using Liquid.WebApi.Http.Attributes;
using Liquid.WebApi.Http.Controllers;
using LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity;
using LiquidCRUDExample.Domain.Queries.v1.GetGenericEntity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace LiquidCRUDExample.WebAPI.Controllers
{
    [ApiController]
    [SwaggerCultureHeader]
    [Route("api/[controller]")]
    public class GenericCRUDController<TEntity, TIdentifier> : BaseController where TEntity : RepositoryEntity<TIdentifier>
    {
        public GenericCRUDController(
            ILoggerFactory loggerFactory,
            IMediator mediator,
            ILightContext context,
            ILightTelemetry telemetry,
            ILocalization localization) : base(loggerFactory, mediator, context, telemetry, localization)
        { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerCultureHeader]
        public async Task<IActionResult> AddAsync(TEntity entity) => await ExecuteAsync(new AddGenericEntityCommand<TEntity, TIdentifier>(entity), HttpStatusCode.Created);

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerCultureHeader]
        public async Task<IActionResult> GetByIdAsync(TIdentifier id) => await ExecuteAsync(new GetGenericEntityQuery<TEntity, TIdentifier>(id), HttpStatusCode.Created);
    }
}

using Liquid.Core.Context;
using Liquid.Core.Localization;
using Liquid.Core.Telemetry;
using LiquidCRUDExample.Domain.Infrastructure.Repositories.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LiquidCRUDExample.WebAPI.Controllers
{
    public class CategoryController : GenericCRUDController<Category, int>
    {
        public CategoryController(
            ILoggerFactory loggerFactory,
            IMediator mediator,
            ILightContext context,
            ILightTelemetry telemetry,
            ILocalization localization) : base(loggerFactory, mediator, context, telemetry, localization) { }
    }
}

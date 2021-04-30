using FluentValidation.AspNetCore;
using Liquid.Core.DependencyInjection;
using Liquid.Domain.Extensions;
using Liquid.Repository;
using Liquid.WebApi.Http.Extensions;
using LiquidCRUDExample.Domain;
using LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity;
using LiquidCRUDExample.Domain.Infrastructure.Repositories.Entities;
using LiquidCRUDExample.Domain.Queries.v1.GetGenericEntity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LiquidCRUDExample.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.ConfigureLiquidHttp();
            services.AddLiquidSwagger();

            services.AddAutoMapper(typeof(IDomainMark).Assembly);
            services.AddDomainRequestHandlers(typeof(IDomainMark).Assembly);

            RegisterCrud<Product, int>(services);
            RegisterCrud<Category, int>(services);

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IDomainMark>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseLiquidSwagger();
            app.ConfigureApplication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void RegisterCrud<TEntity, TIdentifier>(IServiceCollection services) where TEntity : RepositoryEntity<TIdentifier>
        {
            services.AddTransient<IRequestHandler<AddGenericEntityCommand<TEntity, TIdentifier>, AddGenericEntityCommandResponse<TIdentifier>>, AddGenericEntityCommandHandler<TEntity, TIdentifier>>();
            services.AddTransient<IRequestHandler<GetGenericEntityQuery<TEntity, TIdentifier>, GetGenericEntityQueryResponse<TEntity>>, GetGenericEntityQueryHandler<TEntity, TIdentifier>>();
        }
    }
}

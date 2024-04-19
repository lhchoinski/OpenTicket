using System;
using Dapper;
using Microsoft.OpenApi.Models;
using OpenTicket.Domain.Handlers;
using OpenTicket.Domain.Repository;
using OpenTicket.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using OpenTicket.Infra.Data.Mappings;
using OpenTicket.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OpenTicket.Api.Extensions
{
    public static class ServicesExtensions
    {
        #region Services

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DataContext, DataContext>(provider => new DataContext(configuration["ConnectionString:Connection"]));
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<EmployeeHandler, EmployeeHandler>();
            services.AddTransient<TicketHandler, TicketHandler>();
            services.AddTransient<ManagerTicketHandler, ManagerTicketHandler >();
            
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IManagerTicketRepository, ManagerTicketRepository >();
        }

        #endregion

        #region Swagger

        /// <summary>
        /// Adds the s to swagger.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static IServiceCollection AddSToSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "OpenTicket API",
                        Description = "OpenTicket API",
                    });
            });
        }

        /// <summary>
        /// The configure swagger.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public static void ConfigureSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.DocumentTitle = "OpenTicket API";
            });
        }

        #endregion

        #region Dapper

        /// <summary>
        /// Dappers the mapper.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public static void DapperMapper(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));
        }
        #endregion
    }
}

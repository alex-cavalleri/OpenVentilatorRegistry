using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;
using System.Collections.Generic;
using System.Reflection;
using VentilatorRegistry.API.CommandHandlers;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.InMemoryQueryExecutor;
using VentilatorRegistry.API.QueryExecutors.Results;
using VentilatorRegistry.API.QueryHandlers;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API
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
            services.AddControllers();
            services.AddMvc();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Title = Assembly.GetEntryAssembly().GetName().Name;
                };
            });
            services.AddMediatR(typeof(Startup));
            //REPOSITORIES
            services.AddSingleton<IVentilatorRepository, VentilatorInMemoryRepository>();
            services.AddSingleton<IVentilatorModelRepository, VentilatorModelInMemoryRepository>();
            services.AddSingleton<IHospitalOrganizationRepository, HospitalOrganizationInMemoryRepository>();
            //QUERYEXECUTORS
            services.AddTransient<IQueryExecutor<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>>, GetHospitalOrganizationsInMemoryQueryExecutor>();
            services.AddTransient<IQueryExecutor<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>>, GetHospitalsInMemoryQueryExecutor>();
            services.AddTransient<IQueryExecutor<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>>, GetVentilatorsInMemoryQueryExecutor>();
            services.AddTransient<IQueryExecutor<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>>, GetVentilatorModelsInMemoryQueryExecutor>();
            //QUERYHANDLER
            services.AddTransient<IQueryHandler<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>>, GetHospitalOrganizationsQueryHandler>();
            services.AddTransient<IQueryHandler<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>>, GetHospitalsQueryHandler>();
            services.AddTransient<IQueryHandler<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>>, GetVentilatorsQueryHandler>();
            services.AddTransient<IQueryHandler<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>>, GetVentilatorModelsQueryHandler>();
            //COMMANDSHANDLERS
            services.AddTransient<ICommandHandler<CreateHospitalOrganizationCommand, int>, CreateHospitalOrganizationCommandHandler>();
            services.AddTransient<ICommandHandler<CreateHospitalCommand, int>, CreateHospitalCommandHandler>();
            services.AddTransient<ICommandHandler<CreateVentilatorCommand, int>, CreateVentilatorCommandHandler>();
            services.AddTransient<ICommandHandler<CreateVentilatorModelCommand, int>, CreateVentilatorModelCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

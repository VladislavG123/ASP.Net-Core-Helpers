using Calabonga.UnitOfWork.Controllers.DependencyContainer;
using MicroserviceTest.AppStart.Configures;
using MicroserviceTest.AppStart.ConfigureServices;
using MicroserviceTest.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceTest
{
    /// <summary>
    /// Startup entry
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesBase.ConfigureServices(services, Configuration);
            ConfigureServicesAuthentication.ConfigureServices(services, Configuration);
            ConfigureServicesSwagger.ConfigureServices(services, Configuration);
            ConfigureServicesCors.ConfigureServices(services, Configuration);
            ConfigureServicesControllers.ConfigureServices(services);
            ConfigureServicesMediator.ConfigureServices(services);
            ConfigureServicesValidators.ConfigureServices(services);

            DependencyContainer.Common(services);
            NimbleDependencyContainer.ConfigureServices(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="mapper"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            AutoMapper.IConfigurationProvider mapper)
        {
            ConfigureCommon.Configure(app, env, mapper);
            ConfigureEndpoints.Configure(app);
        }
    }
}
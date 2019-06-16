using Autofac;
using Autofac.Extensions.DependencyInjection;
using CQRS.HomeBudget.CompositionRoot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRS.HomeBudget.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return ConfigureContainer(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private IServiceProvider ConfigureContainer(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            Configuration.ConfigureEventFlow(containerBuilder);
            containerBuilder.Populate(services);
            containerBuilder.RegisterModules();

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}

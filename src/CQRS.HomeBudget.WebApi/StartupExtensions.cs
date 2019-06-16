using Autofac;
using CQRS.HomeBudget.CompositionRoot;
using EventFlow;
using EventFlow.AspNetCore.Extensions;
using EventFlow.Autofac.Extensions;
using EventFlow.EventStores.Files;
using EventFlow.Extensions;
using Microsoft.Extensions.Configuration;

namespace CQRS.HomeBudget.WebApi
{
    internal static class StartupExtensions
    {
        internal static void ConfigureEventFlow(this IConfiguration configuration, ContainerBuilder containerBuilder)
        {
            EventFlowOptions.New
                .UseAutofacContainerBuilder(containerBuilder)
                .AddAspNetCore()
                .RegisterModules()
                .UseFilesEventStore(FilesEventStoreConfiguration.Create("./evt-store"));
        }
    }
}
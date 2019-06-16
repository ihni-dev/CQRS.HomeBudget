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
        internal static void ConfigureEventFlow(this IEventFlowOptions eventFlowOptions,
            IConfiguration configuration,
            ContainerBuilder containerBuilder)
        {
            eventFlowOptions
                .UseAutofacContainerBuilder(containerBuilder)
                .AddAspNetCore(c => c
                    .RunBootstrapperOnHostStartup()
                    .UseMvcJsonOptions()
                    .UseModelBinding()
                    .AddUserClaimsMetadata()
                    .UseLogging()
                    .AddMetadataProviders()
                    .UseModelBinding()
                    .AddUriMetadata()
                    .AddRequestHeadersMetadata())
                .RegisterModules()
                .UseFilesEventStore(FilesEventStoreConfiguration.Create("./evt-store"))
                .UseConsoleLog();
        }
    }
}
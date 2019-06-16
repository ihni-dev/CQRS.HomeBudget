using CQRS.HomeBudget.Application.Test.Commands;
using CQRS.HomeBudget.Domain.Test.Events;
using CQRS.HomeBudget.ReadModels.Test;
using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace CQRS.HomeBudget.CompositionRoot.EventFlowModules
{
    internal class TestModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            RegisterEvents(eventFlowOptions);
            RegisterCommands(eventFlowOptions);
            RegisterCommandHandlers(eventFlowOptions);
            RegisterReadStores(eventFlowOptions);
        }

        private void RegisterEvents(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddEvents(typeof(TestCreated));
        }

        private void RegisterCommands(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddCommands(typeof(CreateTest));
        }

        private void RegisterCommandHandlers(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddCommandHandlers(typeof(CreateTestHandler));
        }

        private void RegisterReadStores(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.UseInMemoryReadStoreFor<TestReadModel>();
        }
    }
}
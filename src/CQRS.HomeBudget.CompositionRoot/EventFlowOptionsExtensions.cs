using CQRS.HomeBudget.CompositionRoot.EventFlowModules;
using EventFlow;

namespace CQRS.HomeBudget.CompositionRoot
{
    public static class EventFlowOptionsExtensions
    {
        public static IEventFlowOptions RegisterModules(this IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.RegisterModule(new TestModule());

            return eventFlowOptions;
        }
    }
}

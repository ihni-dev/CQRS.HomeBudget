using CQRS.HomeBudget.Domain.Test;
using CQRS.HomeBudget.Domain.Test.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace CQRS.HomeBudget.ReadModels.Test
{
    public class TestReadModel : IReadModel, IAmReadModelFor<TestAggregate, TestAggregateId, TestCreated>
    {
        public string Id { get; set; }
        public string TestName { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<TestAggregate, TestAggregateId, TestCreated> testCreated)
        {
            Id = testCreated.AggregateIdentity.Value;
            TestName = testCreated.AggregateEvent.TestName;
        }
    }
}
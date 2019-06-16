using CQRS.HomeBudget.Domain.Test.Events;
using EventFlow.Aggregates;

namespace CQRS.HomeBudget.Domain.Test
{
    public class TestAggregate : AggregateRoot<TestAggregate, TestAggregateId>, IEmit<TestCreated>
    {
        public TestAggregate(TestAggregateId id) : base(id)
        {
        }

        public string TestName { get; protected set; } = string.Empty;

        public void Create(string name)
        {
            Emit(new TestCreated(name));
        }

        public void Apply(TestCreated testCreated)
        {
            TestName = testCreated.TestName;
        }
    }
}

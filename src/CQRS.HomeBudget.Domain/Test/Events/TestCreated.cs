using EventFlow.Aggregates;

namespace CQRS.HomeBudget.Domain.Test.Events
{
    public class TestCreated : IAggregateEvent<TestAggregate, TestAggregateId>
    {
        public TestCreated(string testName)
        {
            TestName = testName;
        }

        public string TestName { get; }
    }
}
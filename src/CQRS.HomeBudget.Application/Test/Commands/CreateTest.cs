using CQRS.HomeBudget.Domain.Test;
using EventFlow.Commands;

namespace CQRS.HomeBudget.Application.Test.Commands
{
    public class CreateTest : Command<TestAggregate, TestAggregateId>
    {
        public CreateTest(TestAggregateId id, string testName) : base(id)
        {
            Id = id;
            TestName = testName;
        }

        public TestAggregateId Id { get; }
        public string TestName { get; }
    }
}

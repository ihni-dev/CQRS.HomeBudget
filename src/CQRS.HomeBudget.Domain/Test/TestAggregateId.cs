using EventFlow.Core;

namespace CQRS.HomeBudget.Domain.Test
{
    public class TestAggregateId : Identity<TestAggregateId>
    {
        public TestAggregateId(string value) : base(value)
        {
        }
    }
}
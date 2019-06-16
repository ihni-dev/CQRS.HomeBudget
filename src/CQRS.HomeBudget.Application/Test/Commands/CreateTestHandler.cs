using CQRS.HomeBudget.Domain.Test;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.HomeBudget.Application.Test.Commands
{
    public class CreateTestHandler : CommandHandler<TestAggregate, TestAggregateId, CreateTest>
    {
        public override Task ExecuteAsync(TestAggregate aggregate, CreateTest command, CancellationToken cancellationToken)
        {
            aggregate.Create(command.TestName);
            return Task.FromResult(0);
        }
    }
}
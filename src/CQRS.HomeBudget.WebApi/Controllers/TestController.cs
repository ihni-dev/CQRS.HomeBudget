using CQRS.HomeBudget.Application.Test.Commands;
using CQRS.HomeBudget.Domain.Test;
using CQRS.HomeBudget.ReadModels.Test;
using EventFlow;
using EventFlow.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS.HomeBudget.WebApi.Controllers
{
    public class TestController : ApiControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public TestController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("{testAggregateIdValue}")]
        public async Task<IActionResult> GetAsync(string testAggregateIdValue)
        {
            var testAggregateId = TestAggregateId.With(testAggregateIdValue);
            var testAggregate = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<TestReadModel>(testAggregateId), default);

            return Ok(testAggregate);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string testName)
        {
            var testAggregateId = TestAggregateId.New;
            await _commandBus.PublishAsync(new CreateTest(testAggregateId, testName), default);

            return CreatedAtAction(nameof(GetAsync), new { testAggregateIdValue = testAggregateId.ToString() },
                new { id = testAggregateId.Value, name = testName });
        }
    }
}
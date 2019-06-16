using Microsoft.AspNetCore.Mvc;

namespace CQRS.HomeBudget.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
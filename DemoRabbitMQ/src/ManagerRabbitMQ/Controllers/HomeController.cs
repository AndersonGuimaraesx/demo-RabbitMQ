using Core.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace ManagerRabbitMQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly StartWorkRabbitMQ _startWorkRabbitMQ;

        public HomeController(StartWorkRabbitMQ startWorkRabbitMQ)
        {
            _startWorkRabbitMQ = startWorkRabbitMQ;
        }

        [HttpGet("Hello-World")]
        public IActionResult Get()
        {
            _startWorkRabbitMQ.CreateWorker();

            return Ok();
        }
    }
}

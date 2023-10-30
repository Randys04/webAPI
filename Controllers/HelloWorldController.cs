using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wepAPI.Services;

namespace wepAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        TasksContext tasksContext;

        public HelloWorldController(IHelloWorldService phelloWorldService, ILogger<HelloWorldController> logger, TasksContext _tasksContext)
        {
            _logger = logger;
            helloWorldService = phelloWorldService;
            tasksContext = _tasksContext;
        }

        [HttpGet]
        public IActionResult getHelloWorld()
        {
            _logger.LogInformation("Retornando un Hello World");
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createDB")]
        public IActionResult createDataBase()
        {
            tasksContext.Database.EnsureCreated();
            return Ok();
        }
    }
}

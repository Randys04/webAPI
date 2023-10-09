using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wepAPI.Services;

namespace wepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService phelloWorldService, ILogger<HelloWorldController> logger) 
        {
            _logger = logger;
            helloWorldService = phelloWorldService;
        }

        public IActionResult getHelloWorld()
        {
            _logger.LogInformation("Retornando un Hello World");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}

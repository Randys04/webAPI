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

        public HelloWorldController(IHelloWorldService phelloWorldService) 
        {
            helloWorldService = phelloWorldService;
        }

        public IActionResult getHelloWorld()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using wepAPI.Services;
using wepAPI.Models;
using Task = wepAPI.Models.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            taskService = _taskService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.Get()); 
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] Task task)
        {
            taskService.Save(task);
            return Ok();
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Task task)
        {
            taskService.Update(id, task);
            return Ok();
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.Delete(id);
            return Ok();
        }
    }
}

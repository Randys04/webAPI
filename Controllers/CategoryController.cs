using Microsoft.AspNetCore.Mvc;
using wepAPI.Models;
using wepAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wepAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        { 
            categoryService = _categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryService.Get());
        }


        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            
            categoryService.Save(category);
            return Ok();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            categoryService.Update(id, category);
            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}

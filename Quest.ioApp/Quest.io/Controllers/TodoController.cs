using Microsoft.AspNetCore.Mvc;
using Quest.io.Models;
using Quest.io.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quest.io.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoServices _todoServices;

        public TodoController(TodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<List<Todo>> Get() => await _todoServices.GetAsync();
        

        // GET api/Todo/6567fef62a1a28c9fa7423a8
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Todo>> Get(string id)
        {
            Todo todo = await _todoServices.GetAsync(id);
            if(todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // POST api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo newTodo)
        {
            await _todoServices.CreateAsync(newTodo);
            return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
        }

        // PUT api/Todo/6567fef62a1a28c9fa7423a8
        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Put(string id, Todo updateTodo)
        {
            Todo todo = await _todoServices.GetAsync(id);
            if(todo == null)
            {
                return NotFound("There is no task with this id: "+ id);
            }
            updateTodo.Id = todo.Id;

            await _todoServices.UpdateAsync(id, updateTodo);

            return Ok("Updated Successfully");
        }

        // DELETE api/Todo/6567fef62a1a28c9fa7423a8
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            Todo todo = await _todoServices.GetAsync(id);
            if (todo == null)
            {
                return NotFound("There is no task with this id: " + id);
            }
           

            await _todoServices.RemoveAsync(id);

            return Ok("Deleted Successfully");
        }
    }
}

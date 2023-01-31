using Microsoft.AspNetCore.Mvc;


using App.BLL.Services.Contracts;
using App.DAL.Model;
using App.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Cors;

namespace App.Pl.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class ToDoTasksController : Controller
    {


        IToDoListRepository _toDoListRepository;
        public ToDoTasksController(IToDoListRepository toDoListRepo)
        {
            _toDoListRepository = toDoListRepo ??
            throw new ArgumentNullException(nameof(toDoListRepo));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Index()

        {
            return Ok(await _toDoListRepository.Get());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetDeptById(int Id)
        {
            return Ok(await _toDoListRepository.GetById(Id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] Assignment task)
        {
            var result = await _toDoListRepository.Create(task);
            if (result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(task);
        }

        [HttpPut]
        public async Task <IActionResult> Put([FromBody] Assignment task)
        {
            await _toDoListRepository.Update(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _toDoListRepository?.Delete(id);
            return Ok(id);
        }
    }
}


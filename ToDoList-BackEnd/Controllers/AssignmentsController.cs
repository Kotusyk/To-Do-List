using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList_BackEnd.Model;
using ToDoList_BackEnd.Repository;
using ToDoList_BackEnd.ToDoListContext;

namespace ToDoList_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentsController : Controller
    {
      //  private readonly ToDoContext _context;
        IToDoListRepository _toDoListRepository;
        public AssignmentsController(IToDoListRepository toDoListRepo)
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
        public async Task<IActionResult> Post([FromBody]Assignment task)
        {
            var result = await _toDoListRepository.Create(task);
            if (result.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("New Task added successfully");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(Assignment task)
        {
            await _toDoListRepository.Update(task);
            return Ok($"Task was updated to '{task.Title}'successfully");
        }

        [HttpDelete("{id}", Name = "Delete")]
        public JsonResult Delete (int id)
        {
            _toDoListRepository?.Delete(id);
            return new JsonResult("Task was deleted successfully");
        }

        //[HttpGet("DetailsGetById/{id}")]

        //public async Task<IActionResult> Details(int id)
        //{
        //    //if (id == null || _toDoListRepository.Assignments == null)
        //    //{FindAsync(m => m.Id == id)
        //    //    return NotFound();
        //    //}

        //    var assignment = await _toDoListRepository.GetById(id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }

        //    return new ObjectResult(assignment);

        //}


        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Route("Create")]

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromBody] Assignment assignment)
        //{
        //    if (_toDoListRepository != null)
        //    {
        //        _toDoListRepository.Create(assignment);
        //        //await _toDoListRepository;

        //    }
        //    return Ok(assignment);
        //    /*Bind("Id,Title,Date,Status")
        //     ////[
        //     //if (ModelState.IsValid)
        //     //{
        //     //    _context.Add(assignment);
        //     //    await _context.SaveChangesAsync();
        //     //   // return RedirectToAction(nameof(Index));
        //     //}
        //     // return View(assignment);*/
        //}

        // GET: Assignments/Edit/5
        //[HttpGet("Edit/{id}")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Assignments == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = await _toDoListRepository.Assignments.FindAsync(id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(assignment);
        //}

        //// POST: Assignments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPut("EditPut/{id}")]
        ////[HttpPut]

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Assignment assignment)
        //{

        //    //Bind("Id,Title,Date,Status")
        //    if (id != assignment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _toDoListRepository.Update(assignment);
        //            await _toDoListRepository.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AssignmentExists(assignment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(assignment);
        //}

        //// GET: Assignments/Delete/5
        //[HttpGet("Delete/{id}")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _toDoListRepository.Assignments == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = await _toDoListRepository.Assignments
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assignment);
        //}

        //// POST: Assignments/Delete/5
        ////   [HttpPost("{id}", Name = "Delete")]
        //[HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_toDoListRepository.Assignments == null)
        //    {
        //        return Problem("Entity set 'ToDoContext.Assignments'  is null.");
        //    }
        //    var assignment = await _toDoListRepository.Assignments.FindAsync(id);
        //    if (assignment != null)
        //    {
        //        _toDoListRepository.Assignments.Remove(assignment);
        //    }

        //    await _toDoListRepository.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AssignmentExists(int id)
        //{
        //    return _toDoListRepository.Assignments.Any(e => e.Id == id);
        //}

        //public AssignmentsController(ToDoContext context)
        //{
        //    _toDoListRepository = context;
        //}

        //[HttpGet]
        //[Route("Get")]
        //public async Task<IActionResult> Index()

        //{
        //    return Ok(await _toDoListRepository.GetAll());
        //}

        //[HttpGet("DetailsGetById/{id}")]


        //public async Task<IActionResult> Details(int id)
        //{
        //    //if (id == null || _toDoListRepository.Assignments == null)
        //    //{FindAsync(m => m.Id == id)
        //    //    return NotFound();
        //    //}

        //    var assignment = await _toDoListRepository.GetById(id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }

        //    return new ObjectResult(assignment);
        //}


        //// POST: Assignments/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Route("Create")]

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> /*void Task<IActionResult>*/ Create([FromBody] Assignment assignment)
        //{
        //   // var  = 
        //    if (_toDoListRepository != null)
        //    {
        //        _toDoListRepository.Create(assignment);
        //         //await _toDoListRepository;

        //    }
        //    return Ok(assignment);
        //   /*Bind("Id,Title,Date,Status")
        //    ////[
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _toDoListRepository.Add(assignment);
        //    //    await _context.SaveChangesAsync();
        //    //   // return RedirectToAction(nameof(Index));
        //    //}
        //    // return View(assignment);*/
        //}

        //// GET: Assignments/Edit/5
        //[HttpGet("Edit/{id}")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Assignments == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = await _context.Assignments.FindAsync(id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(assignment);
        //}

        //// POST: Assignments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPut("EditPut/{id}")]
        ////[HttpPut]

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] Assignment assignment)
        //{

        //    //Bind("Id,Title,Date,Status")
        //    if (id != assignment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(assignment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AssignmentExists(assignment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(assignment);
        //}

        //// GET: Assignments/Delete/5
        //[HttpGet("Delete/{id}")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Assignments == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignment = await _context.Assignments
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (assignment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assignment);
        //}

        //// POST: Assignments/Delete/5
        ////   [HttpPost("{id}", Name = "Delete")]
        //[HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Assignments == null)
        //    {
        //        return Problem("Entity set 'ToDoContext.Assignments'  is null.");
        //    }
        //    var assignment = await _context.Assignments.FindAsync(id);
        //    if (assignment != null)
        //    {
        //        _context.Assignments.Remove(assignment);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AssignmentExists(int id)
        //{
        //  return _context.Assignments.Any(e => e.Id == id);
        //}
    }
}

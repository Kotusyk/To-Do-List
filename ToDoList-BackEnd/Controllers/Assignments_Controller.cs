//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ToDoList_BackEnd.Model;
//using ToDoList_BackEnd.Repository;
//using ToDoList_BackEnd.ToDoListContext;

//namespace ToDoList_BackEnd.Controllers
//{
//    [Route("api/[controller]")]
//    public class AssignmentsController : Controller
//    {

//        IToDoListRepository _toDoListRepository;
//        public AssignmentsController(IToDoListRepository toDoListRepo)
//        {
//            _toDoListRepository = toDoListRepo;
//        }

//        [HttpGet(Name = "GetAllTasks")]
//        public IEnumerable<Assignment> Get() => _toDoListRepository.Get();

//        [HttpGet("{id}", Name = "GetTask")]
//        public IActionResult Get(int id)
//        {
//            Assignment task = _toDoListRepository.Get(id);
//            if (task == null)
//            {
//                return NotFound();
//            }
//            return View(task);
//        }
//        [HttpPost]
//        public IActionResult Create([FromBody] Assignment task)
//        {
//            if (task == null)
//            {
//                return BadRequest();
//            }
//            _toDoListRepository.Create(task);
//            return CreatedAtRoute("GetToDoItem", new { id = task.Id }, task);
//        }
//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] Assignment updatedTask)
//        {
//            if (updatedTask == null || updatedTask.Id != id)
//            {
//                return BadRequest();
//            }

//            var item = _toDoListRepository.Get(id);
//            if (item == null)
//            {
//                return BadRequest();
//            }
//            _toDoListRepository.Update(item);
//            return RedirectToRoute("GetAllTasks");

//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var deletedTask = _toDoListRepository.Delete(id);
//            if (deletedTask == null)
//            {
//                return NotFound();
//            }
//            return View(deletedTask);
//        }
//    }
//}
//// GET: Assignments/Delete/5
//[HttpGet]
//[Route("api/[controller]/Delete/{id}")]
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null || _context.Assignment == null)
//    {
//        return NotFound();
//    }

//    var assignment = await _context.Assignment
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (assignment == null)
//    {
//        return NotFound();
//    }

//    return View(assignment);
//}

//// POST: Assignments/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    if (_context.Assignment == null)
//    {
//        return Problem("Entity set 'ToDoContext.Assignment'  is null.");
//    }
//    var assignment = await _context.Assignment.FindAsync(id);
//    if (assignment != null)
//    {
//        _context.Assignment.Remove(assignment);
//    }

//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}




//private readonly ToDoContext _context;

//public AssignmentsController(ToDoContext context)
//{
//    _context = context;
//    //}
//    [HttpGet]
//    public string GetProducts()
//    {
//        return "list of products";
//    }

//    // GET: Assignments
//    public async Task<IActionResult> Index()
//    {
//        return View(await _context.Assignments.ToListAsync());
//    }

//    //// GET: Assignments/Details/5
//    [HttpGet("{id}")]
//    //[Route("api/[controller]/Details/{id?}")]
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null || _context.Assignments == null)
//        {
//            return NotFound();
//        }

//        var assignment = await _context.Assignments
//            .FirstOrDefaultAsync(m => m.Id == id);
//        if (assignment == null)
//        {
//            return NotFound();
//        }

//        return View(assignment);
//    }

//    //// GET: Assignments/Create
//    //[HttpGet]
//    //[Route("api/[controller]/Create")]

//    //public IActionResult Create()
//    //{
//    //    return View();
//    //}

//    //// POST: Assignments/Create
//    //// To protect from overposting attacks, enable the specific properties you want to bind to.
//    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    //[HttpPost]
//    //[ValidateAntiForgeryToken]
//    //[Route("api/[controller]/Create/")]

//    //public async Task<IActionResult> Create([Bind("Id,Title,Date,Status")] Assignment assignment)
//    //{
//    //    if (ModelState.IsValid)
//    //    {
//    //        _context.Add(assignment);
//    //        await _context.SaveChangesAsync();
//    //        return RedirectToAction(nameof(Index));
//    //    }
//    //    return View(assignment);
//    //}

//    //// GET: Assignments/Edit/5
//    //[HttpGet]
//    //[Route("api/[controller]/Edit/{id}")]

//    //public async Task<IActionResult> Edit(int? id)
//    //{
//    //    if (id == null || _context.Assignment == null)
//    //    {
//    //        return NotFound();
//    //    }

//    //    var assignment = await _context.Assignment.FindAsync(id);
//    //    if (assignment == null)
//    //    {
//    //        return NotFound();
//    //    }
//    //    return View(assignment);
//    //}

//    //// POST: Assignments/Edit/5
//    //// To protect from overposting attacks, enable the specific properties you want to bind to.
//    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    //[HttpPost]
//    //[Route("api/[controller]/Edit")]
//    //[ValidateAntiForgeryToken]
//    //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Status")] Assignment assignment)
//    //{
//    //    if (id != assignment.Id)
//    //    {
//    //        return NotFound();
//    //    }

//    //    if (ModelState.IsValid)
//    //    {
//    //        try
//    //        {
//    //            _context.Update(assignment);
//    //            await _context.SaveChangesAsync();
//    //        }
//    //        catch (DbUpdateConcurrencyException)
//    //        {
//    //            if (!AssignmentExists(assignment.Id))
//    //            {
//    //                return NotFound();
//    //            }
//    //            else
//    //            {
//    //                throw;
//    //            }
//    //        }
//    //        return RedirectToAction(nameof(Index));
//    //    }
//    //    return View(assignment);
//    //}



//    private bool AssignmentExists(int id)
//    {
//        return _context.Assignments.Any(e => e.Id == id);
//    }
//}
//        }
//    }
//}
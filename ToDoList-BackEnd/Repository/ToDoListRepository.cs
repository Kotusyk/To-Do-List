using Microsoft.EntityFrameworkCore;
using ToDoList_BackEnd.Model;
using ToDoList_BackEnd.ToDoListContext;
namespace ToDoList_BackEnd.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoContext _context;

        public ToDoListRepository(ToDoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Assignment>> Get()
        {
            return await _context.Assignments.ToListAsync();
        }
        public async Task<Assignment> GetById(int Id)
        {
            return await _context.Assignments.FindAsync(Id);
        }
        public async Task<Assignment> Create(Assignment assignmentForCreating)
        {
            _context.Assignments.Add(assignmentForCreating);
             await _context.SaveChangesAsync();
            return assignmentForCreating;

        }
        public async Task<Assignment> Update(Assignment assignmentForUpdating)
        {
            _context.Entry(assignmentForUpdating).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return assignmentForUpdating;
        }
        public bool Delete(int Id)
        {
            bool result = false;
            var assignment = _context.Assignments.Find(Id);
            if (assignment != null)
            {
                _context.Entry(assignment).State = EntityState.Deleted;
                _context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        /*public IEnumerable<Assignment> Get()
        {
             return  _context.Assignments;
          //  return await _context.Assignments.ToListAsync();
        }
        public Assignment Get(int id) => _context.Assignments.Find(id);

        public void Create (Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }


        public void Update (Assignment updatedAssignment)
        {
            Assignment cuurentItem = Get(updatedAssignment.Id);
            cuurentItem.Title = updatedAssignment.Title;
            cuurentItem.Date = updatedAssignment.Date;
            cuurentItem.Status = updatedAssignment.Status;


            _context.Assignments.Update(cuurentItem);
            _context.SaveChanges();
        }
        public Assignment Delete(int id)
        {
            Assignment assigmentForDeleting = Get(id); 

            if (assigmentForDeleting != null)
            {
                _context.Assignments.Remove(assigmentForDeleting);
                _context.SaveChanges();
            }
            return assigmentForDeleting;
        }
        */
    }
}

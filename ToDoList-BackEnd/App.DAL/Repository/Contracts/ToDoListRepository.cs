using App.DAL.Data;
using App.DAL.Model;
using App.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DAL.Repository.Contracts
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
            _context.Entry(assignmentForUpdating).State = EntityState.Modified;
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

    }
}

using App.DAL.Data;
using App.DAL.Model;
using App.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


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

            var data = _context.Assignments.Where(s => s.Id == assignmentForUpdating.Id)
                                                   .FirstOrDefault<Assignment>();

            if (data != null)
            {
             //   data.Id = assignmentForUpdating.Id;
                data.Title = assignmentForUpdating.Title;
                data.Date = assignmentForUpdating.Date;
                data.Status = assignmentForUpdating.Status;
                data.Urgently = assignmentForUpdating.Urgently;
                await _context.SaveChangesAsync();
                return data;
            }
          
            //_context.Assignments.Update(assignmentForUpdating);
            //_context.SaveChanges();

            return assignmentForUpdating;


            //var data = _context.Assignments.FirstOrDefault(x => x.Id  == assignmentForUpdating.Id);

            //if (data != null && !AssignmentExists(assignmentForUpdating.Id))
            //{
            //    data.Id = assignmentForUpdating.Id;
            //    data.Title = assignmentForUpdating.Title;
            //    data.Date = assignmentForUpdating.Date;
            //    data.Status = assignmentForUpdating.Status;
            //    data.Urgently = assignmentForUpdating.Urgently;
            //    _context.SaveChanges();
            //    // It will redirect to
            //    // the Read method
            //    return data ;
            //}
            //else
            //{
            //    throw new ValidationException("Inspection with this id ain't exist");
            //}

            //_context.Entry(assignmentForUpdating).State = EntityState.Modified;
            ////  _context.Assignments.Update(assignmentForUpdating);
            //await _context.SaveChangesAsync();
            //return assignmentForUpdating;


            //if (!AssignmentExists(assignmentForUpdating.Id))
            //{
            //    throw new ValidationException("Inspection with this id ain't exist");
            //}
            //  var inspectionType = _mapper.Map<InspectionTypeDto, InspectionType>(inspectionTypeDto);


            //_context.Entry(assignmentForUpdating).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return assignmentForUpdating;
        }
        public async Task<Assignment> Delete(int id)
        {
            var assignment = await _context.Assignments!.FindAsync(id);
            if (assignment == null)
            {
                throw new ValidationException("Not found");
            }
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return assignment;
            //var assignment = _context.Assignments.Find(Id);
            //_context.Entry(assignment).State = EntityState.Deleted;
            //await _context.SaveChangesAsync();
            //return assignment;
        }
        private bool AssignmentExists(int id)
        {
            return _context.Assignments!.Any(e => e.Id == id);
        }
        //public bool Delete(int Id)
        //{
        //    bool result = false;
        //    var assignment = _context.Assignments.Find(Id);
        //    if (assignment != null)
        //    {
        //        _context.Entry(assignment).State = EntityState.Deleted;
        //        _context.SaveChanges();
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

    }
}

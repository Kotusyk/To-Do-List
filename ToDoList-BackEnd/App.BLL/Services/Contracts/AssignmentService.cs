using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Repository.Contracts;
using App.BLL.Services.Contracts;
using App.DAL.Model;

namespace App.BLL.Services.Contracts
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IToDoListRepository _repository;

        public AssignmentService(IToDoListRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Assignment>> Get()
        {
            return await _repository.Get();
        }
        public async Task<Assignment> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }
        public async Task<Assignment> Create(Assignment assignmentForCreating)
        {
            return await _repository.Create(assignmentForCreating);

        }
        public Task<Assignment> Update(Assignment assignmentForUpdating)
        {
            return _repository.Update(assignmentForUpdating);

        }
        public Task<Assignment> Delete(int Id)
        {
            return _repository.Delete(Id);
        }
    }
}

using App.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Model;

namespace App.DAL.Repository.Contracts
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<Assignment>> Get();
        Task<Assignment> GetById(int Id);
        Task<Assignment> Create(Assignment assignmentForCreating);
        Task<Assignment> Update(Assignment assignmentForUpdating);
        bool Delete(int Id);
    }
}

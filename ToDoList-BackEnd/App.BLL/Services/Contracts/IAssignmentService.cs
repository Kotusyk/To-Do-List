using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Model;

namespace App.BLL.Services.Contracts
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> Get();
        Task<Assignment> GetById(int Id);
        Task<Assignment> Create(Assignment assignmentForCreating);
        Task<Assignment> Update(Assignment assignmentForUpdating);
        Task<Assignment> Delete(int Id);
    }
}

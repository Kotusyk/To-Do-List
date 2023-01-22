using Microsoft.AspNetCore.Mvc;
using ToDoList_BackEnd.Model;

namespace ToDoList_BackEnd.Repository
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<Assignment>> Get();
        Task<Assignment> GetById(int Id);
        Task<Assignment> Create(Assignment assignmentForCreating);
        Task<Assignment> Update(Assignment assignmentForUpdating);
        bool Delete(int Id);

        //IEnumerable<Assignment> Get();
        //Assignment Get(int id);
        //void Create(Assignment item);
        //void Update(Assignment item);
        //Assignment Delete(int id);
    }
}


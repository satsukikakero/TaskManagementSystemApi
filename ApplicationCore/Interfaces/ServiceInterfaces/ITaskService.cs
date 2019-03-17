using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        void Insert(Task task);
        void DeleteById(int id);
        void Delete(Task task);
        void Update(Task task);
        IEnumerable<TaskType> GetAllTaskTypes();
        IEnumerable<TaskStatus> GetTaskStatuses();
        IEnumerable<User> GetAllAssigniesForTask(Task task);
        IEnumerable<Task> GetAllEager();
        Task GetByIdEager(int id);
    }
}

using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ITaskRepository: IRepository<Task>
    {
        IEnumerable<TaskType> GetAllTaskTypes();
        IEnumerable<TaskStatus> GetTaskStatuses();
        IEnumerable<User> GetAllAssigniesForTask(Task task);
        IEnumerable<Task> GetAllEager();
        Task GetByIDEager(int id);
    }
}

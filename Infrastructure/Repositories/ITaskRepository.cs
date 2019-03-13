using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface ITaskRepository: IRepository<Task>
    {
        IEnumerable<TaskType> GetAllTaskTypes();
        IEnumerable<TaskStatus> GetTaskStatuses();
        IEnumerable<User> GetAllAssigniesForTask(Task task);
    }
}

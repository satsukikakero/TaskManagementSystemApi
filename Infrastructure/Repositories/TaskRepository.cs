using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private readonly DbContext _context;

        public TaskRepository(DbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAllAssigniesForTask(Task task)
        {
            return _context.Users.Where(user => user.UserTasks.All(userTask => userTask.TaskId == task.Id));
        }

        public IEnumerable<TaskType> GetAllTaskTypes()
        {
            return _context.TaskTypes.ToList();
        }

        public IEnumerable<TaskStatus> GetTaskStatuses()
        {
            return _context.TaskStatuses.ToList();
        }
    }
}

using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Task> GetAllEager()
        {
            return _context.Tasks
               .Include(t => t.TaskDetails)
                   .ThenInclude(td => td.Type)
               .Include(t => t.TaskDetails)
                   .ThenInclude(td => td.Status);
        }

        public IEnumerable<TaskType> GetAllTaskTypes()
        {
            return _context.TaskTypes.ToList();
        }

        public Task GetByIDEager(int id)
        {
            return _context.Tasks
               .Where(t => t.Id == id)
               .Include(t => t.TaskDetails)
                   .ThenInclude(td => td.Type)
               .Include(t => t.TaskDetails)
                   .ThenInclude(td => td.Status)
               .FirstOrDefault();
        }

        public IEnumerable<TaskStatus> GetTaskStatuses()
        {
            return _context.TaskStatuses.ToList();
        }

        public override void Update(Task entityToUpdate)
        {
            _context.Tasks.Update(entityToUpdate);
            _context.SaveChanges();
        }
    }
}

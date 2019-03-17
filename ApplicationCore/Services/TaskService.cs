using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;

namespace ApplicationCore.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        public virtual IEnumerable<Task> GetAllEager()
        {
            return _taskRepository.GetAllEager();
        }

        public void Delete(Task task)
        {
            _taskRepository.Delete(task);
        }

        public void DeleteById(int id)
        {
            _taskRepository.DeleteByid(id);
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public IEnumerable<User> GetAllAssigniesForTask(Task task)
        {
            return _taskRepository.GetAllAssigniesForTask(task);
        }

        public IEnumerable<TaskType> GetAllTaskTypes()
        {
            return _taskRepository.GetAllTaskTypes();
        }

        public Task GetById(int id)
        {
            return _taskRepository.GetByID(id);
        }

        public IEnumerable<TaskStatus> GetTaskStatuses()
        {
            return _taskRepository.GetTaskStatuses();
        }

        public void Insert(Task task)
        {
            _taskRepository.Insert(task);
        }

        public void Update(Task task)
        {
            _taskRepository.Update(task);
        }

        public Task GetByIdEager(int id)
        {
            return _taskRepository.GetByIDEager(id);
        }
    }
}

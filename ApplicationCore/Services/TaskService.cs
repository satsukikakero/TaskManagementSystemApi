using System;
using System.Collections.Generic;
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
            return GetAllTaskTypes();
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
    }
}

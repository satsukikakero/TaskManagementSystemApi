using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;

namespace ApplicationCore.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository ?? throw new ArgumentNullException(nameof(userTaskRepository));
        }

        public void Delete(UserTask userTask)
        {
            _userTaskRepository.Delete(userTask);
        }

        public void DeleteById(int id)
        {
            _userTaskRepository.DeleteByid(id);
        }

        public IEnumerable<UserTask> GetAll()
        {
            return _userTaskRepository.GetAll();
        }

        public UserTask GetById(int id)
        {
            return _userTaskRepository.GetByID(id);
        }

        public void Insert(UserTask userTask)
        {
            _userTaskRepository.Insert(userTask);
        }

        public void Update(UserTask userTask)
        {
            _userTaskRepository.Update(userTask);
        }
    }
}

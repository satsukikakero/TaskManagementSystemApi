using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IUserTaskService
    {
        IEnumerable<UserTask> GetAll();
        UserTask GetById(int id);
        void Insert(UserTask userTask);
        void DeleteById(int id);
        void Delete(UserTask userTask);
        void Update(UserTask userTask);
    }
}

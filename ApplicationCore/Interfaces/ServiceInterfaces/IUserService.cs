using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        void Insert(User user);
        void DeleteById(string id);
        void Delete(User user);
        void Update(User user);
    }
}

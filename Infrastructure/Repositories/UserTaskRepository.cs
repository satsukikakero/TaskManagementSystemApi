using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserTaskRepository : Repository<UserTask>, IUserTaskRepository
    {
        public UserTaskRepository(DbContext context) : base(context)
        {
        }
    }
}

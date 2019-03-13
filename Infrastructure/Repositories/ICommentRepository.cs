using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface ICommentRepository: IRepository<Comment>
    {
        IEnumerable<CommentType> GetCommentTypes();
        IEnumerable<Comment> GetAllCommentForTask(Task task);
    }
}

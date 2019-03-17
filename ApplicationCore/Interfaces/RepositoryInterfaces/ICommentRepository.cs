using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface ICommentRepository: IRepository<Comment>
    {
        IEnumerable<CommentType> GetCommentTypes();
        IEnumerable<Comment> GetAllCommentForTask(int id);
        DateTime? GetFirstCommentWithReminderDateForGivenTask(int id);
    }
}

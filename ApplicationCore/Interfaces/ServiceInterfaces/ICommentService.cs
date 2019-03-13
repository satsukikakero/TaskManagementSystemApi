using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAll();
        Comment GetById(int id);
        void Insert(Comment comment);
        void DeleteById(int id);
        void Delete(Comment comment);
        void Update(Comment comment);
        IEnumerable<Comment> GetAllCommentForTask(Task task);
        IEnumerable<CommentType> GetCommentTypes();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;

namespace ApplicationCore.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public void Delete(Comment comment)
        {
            _commentRepository.Delete(comment);
        }

        public void DeleteById(int id)
        {
            _commentRepository.DeleteByid(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public IEnumerable<Comment> GetAllCommentForTask(int id)
        {
            return _commentRepository.GetAllCommentForTask(id);
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetByID(id);
        }

        public IEnumerable<CommentType> GetCommentTypes()
        {
            return _commentRepository.GetCommentTypes();
        }

        public void Insert(Comment comment)
        {
            _commentRepository.Insert(comment);
        }

        public void Update(Comment comment)
        {
            _commentRepository.Update(comment);
        }
    }
}

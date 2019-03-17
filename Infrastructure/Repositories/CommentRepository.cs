using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly DbContext _context;

        public CommentRepository(DbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Comment> GetAllCommentForTask(int id)
        {
            return _context.Comments
                .Where(comment => comment.TaskId == id)
                .Include(comment => comment.CommentType)
                .ToList();
        }

        public IEnumerable<CommentType> GetCommentTypes()
        {
            return _context.CommentTypes.ToList();
        }

        public DateTime? GetFirstCommentWithReminderDateForGivenTask(int id)
        {
            Comment comment = _context.Comments.Where(comm => comm.Task.Id == id && comm.ReminderDate.HasValue).FirstOrDefault();
            return comment?.ReminderDate.Value;
        }
    }
}

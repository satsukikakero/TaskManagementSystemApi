﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Comment> GetAllCommentForTask(Task task)
        {
            return _context.Comments.Where(comment => comment.Task.Equals(task)).ToList();
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

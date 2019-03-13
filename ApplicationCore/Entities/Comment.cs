using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Comment: IEntity
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int CommentTypeId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int TaskId { get; set; }

        public Task Task { get; set; }
        public CommentType CommentType { get; set; }
    }
}

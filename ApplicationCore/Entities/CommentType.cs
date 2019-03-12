using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class CommentType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

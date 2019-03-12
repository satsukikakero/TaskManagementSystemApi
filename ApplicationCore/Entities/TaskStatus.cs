using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskDetails> TaskDetails { get; set; }
    }
}

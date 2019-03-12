using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class TaskDetails
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }

        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public Task Task { get; set; }
    }
}

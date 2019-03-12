using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RequiredByDate { get; set; }

        public TaskDetails TaskDetails { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class TaskStatus: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<TaskDetails> TaskDetails { get; set; }
    }
}

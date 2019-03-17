using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class CommentType: IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}

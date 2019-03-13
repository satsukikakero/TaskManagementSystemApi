using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ModelMappers;

namespace TMSApi.ApiModels
{
    public class ApiComment: IApiModel
    {
        public DateTime DateAdded { get; set; }
        public string CommentText { get; set; }
        public string CommentType { get; set; }
        public DateTime? ReminderDate { get; set; }
    }
}

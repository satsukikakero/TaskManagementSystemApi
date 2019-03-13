using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ApiModels;

namespace TMSApi.ModelMappers
{
    public class CommentMapper : IModelMapper<Comment, ApiComment>
    {
        public Comment ConverToDbModel(ApiComment ApiModel)
        {
            throw new NotImplementedException();
        }

        public ApiComment ConvertToApiModel(Comment Model)
        {
            return new ApiComment() { CommentText = Model.CommentText, CommentType = Model.CommentType.Type, DateAdded = Model.DateAdded, ReminderDate = Model.ReminderDate };
        }
    }
}

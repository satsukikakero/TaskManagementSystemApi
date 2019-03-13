using ApplicationCore.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using TMSApi.ApiModels;

namespace TMSApi.ModelMappers
{
    public class TaskMapper : IModelMapper<Task, ApiTask>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICommentRepository _commentRepository;

        public TaskMapper(ITaskRepository taskRepository, ICommentRepository commentRepository)
        {
            _taskRepository = taskRepository;
            _commentRepository = commentRepository;
        }

        public Task ConverToDbModel(ApiTask ApiModel)
        {
            throw new NotImplementedException();
        }

        public ApiTask ConvertToApiModel(Task Model)
        {
            return new ApiTask()
            {
                CreateDate = Model.CreateDate,
                Description = Model.TaskDetails.Description,
                RequestByDate = Model.RequiredByDate,
                Status = Model.TaskDetails.Status.Name,
                Type = Model.TaskDetails.Type.Name,
                AssignedTo = _taskRepository.GetAllAssigniesForTask(Model).ToList(),
                NextActionDate = _commentRepository.GetFirstCommentWithReminderDateForGivenTask(Model.Id)
            };
        }
    }
}

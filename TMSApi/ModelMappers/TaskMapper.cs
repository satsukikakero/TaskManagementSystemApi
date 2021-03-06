﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
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
            return new Task()
            {
                RequiredByDate = ApiModel.RequestByDate,
                CreateDate = ApiModel.CreateDate,
                TaskDetails = new TaskDetails()
                {
                    StatusId = ApiModel.StatusId,
                    TypeId = ApiModel.TypeId,
                    Description = ApiModel.Description
                }
            };
        }

        public ApiTask ConvertToApiModel(Task Model)
        {
            return new ApiTask()
            {
                TaskId = Model.Id,
                CreateDate = Model.CreateDate,
                Description = Model.TaskDetails.Description,
                RequestByDate = Model.RequiredByDate,
                Status = Model.TaskDetails.Status.Name,
                Type = Model.TaskDetails.Type.Name,
                AssignedTo = _taskRepository.GetAllAssigniesForTask(Model).ToList(),
                NextActionDate = _commentRepository.GetFirstCommentWithReminderDateForGivenTask(Model.Id).Value
            };
        }
    }
}

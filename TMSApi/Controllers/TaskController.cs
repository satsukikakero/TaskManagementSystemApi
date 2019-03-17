using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ApiModels;
using TMSApi.ModelMappers;

namespace TMSApi.Controllers
{

    [Authorize]
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : ControllerBase
    {

        public class ValidateModelAttribute : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                context.Result = new JsonResult("Exception: " + context.Exception);
            }

        }

        private ITaskService _tasksService;
        private readonly TaskMapper _taskMapper;

        public TaskController(ITaskService tasksService, TaskMapper taskMapper)
        {
            _tasksService = tasksService;
            _taskMapper = taskMapper;
        }

        [ValidateModelAttribute]
        [HttpPost("addTask")]
        public IActionResult Post([FromBody]ApiModels.ApiTask task)
        {
            var taskModel = _taskMapper.ConverToDbModel(task);
            _tasksService.Insert(taskModel);
            return Ok();
        }

        [HttpGet("getAllTaskTypes")]
        public IActionResult GetAllTasktypes()
        {
            return Ok(new List<TaskType>(_tasksService.GetAllTaskTypes().ToList()));
        }

        [HttpGet("getAllTaskStatuses")]
        public IActionResult GetAllTaskStatuses()
        {
            return Ok(new List<ApplicationCore.Entities.TaskStatus>(_tasksService.GetTaskStatuses().ToList()));
        }

        [HttpGet("getAllTasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _tasksService.GetAllEager().ToList();
            return Ok(tasks);
        }

        [HttpPost("deleteTask")]
        public IActionResult DeleteTask([FromBody]int id)
        {
            _tasksService.DeleteById(id);
            return Ok();
        }

        [HttpGet("getTaskById/{id}")]
        public IActionResult GetTaskById(int id)
        {
            return Ok(_tasksService.GetByIdEager(id));
        }

        [HttpPost("updateTask")]
        public IActionResult UpdateTask([FromBody]ApiModels.ApiTask task)
        {
            var taskModel = _taskMapper.ConverToDbModel(task);
            _tasksService.Update(taskModel);
            return Ok();
        }

    }
}

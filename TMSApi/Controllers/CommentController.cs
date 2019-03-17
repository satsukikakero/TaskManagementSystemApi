using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ModelMappers;

namespace TMSApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Comment")]
    public class CommentController: ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly CommentMapper _commentMapper;

        public CommentController(ICommentService commentService, CommentMapper commentMapper)
        {
            _commentService = commentService;
            _commentMapper = commentMapper;
        }

        [HttpPost("addComment")]
        public IActionResult AddComment([FromBody]ApiModels.ApiComment comment)
        {
            var commentModel = _commentMapper.ConverToDbModel(comment);
            _commentService.Insert(commentModel);
            return Ok(comment);
        }

        [HttpPost("deleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteById(id);
            return Ok();
        }

        [HttpGet("getAllCommentTypes")]
        public IActionResult GetAllCommentTypes()
        {
            return Ok(new List<CommentType>(_commentService.GetCommentTypes().ToList()));
        }

        [HttpGet("getAllCommentsForTask/{id}")]
        public IActionResult GetAllCommentsForTask(int id)
        {
            var comments = _commentService.GetAllCommentForTask(id).ToList();
            return Ok(comments);
        }
    }
}

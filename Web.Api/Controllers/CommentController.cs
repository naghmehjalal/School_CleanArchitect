using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.CourseComment.Requests.Queries;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Commands;
using Core.Application.DTOs.Course.Comment;
using Core.Application.DTOs.Course.Group;
using Core.Domain.Entities.Ent_Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CommentController>
        [HttpGet("GetCommentBy")]
      
        public async Task<ActionResult<CommentDTO>> GetCommentById(int id)
        {
            var commentOBJ = await _mediator.Send(new GetCommentByIdRequest { commentId = id });
            return Ok(commentOBJ);
        }

        // GET api/<CommentController>/5
        [HttpGet("GetCommentByCourse/{id}")]
         public async Task<ActionResult<List<CommentDTO>>> GetCommentByCourse(int id)
        {
           var list=await _mediator.Send(new GetCommentByCourseIdRequest { courseId = id });
            return Ok(list);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateCommentDTO createCommentDTO)
        {

            var command = new CreateCommentRequest {  createCommentDTO= createCommentDTO };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCommentDTO updateCommentDTO)
        {

            updateCommentDTO.CommentId = id;
            var command = new UpdateCommentRequest { updateCommentDTO = updateCommentDTO };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentRequest { commentId = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}

using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Queries;
using Core.Application.DTOs.Course.Course;
using Core.Application.DTOs.Course.Group;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CourseGroupController>
        [HttpGet("GetAllGroup")]
        public async Task<ActionResult<List<CourseGroupDTO>>> GetAllGroup()
        {
            var list = await _mediator.Send(new GetGroupsRequest());
            return Ok(list);
        }

        // GET api/<CourseGroupController>/5
        [HttpGet("GetGroupById/{id}")]
       
        public async Task<ActionResult<CourseGroupDTO>> GetGroupById(int id)
        {
            var obj = await _mediator.Send(new GetGroupByIdRequest { Id = id });
            return Ok(obj);
        }


        [HttpGet("GetSubGroup/{id}")]
      
        public async Task<ActionResult<List<CourseGroupDTO>>> GetSubGroup(int id)
        {
            var list = await _mediator.Send(new GetSubGroupRequest { ParentId = id });
            return Ok(list);
        }

        // POST api/<CourseGroupController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseGroupDTO createCourseGroupDTO)
        {
            var command = new CreateGroupRequest { groupDTO = createCourseGroupDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CourseGroupController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateCourseGroupDTO updateCourseGroupDTO)
        {
            updateCourseGroupDTO.GroupId = id;
            var command = new UpdateGroupRequest { groupDTO = updateCourseGroupDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CourseGroupController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteGroupRequest { groupId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

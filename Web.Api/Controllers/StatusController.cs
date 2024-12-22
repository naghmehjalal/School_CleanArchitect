using Core.Application.CQRS.CQRS_Course.CourseLevel.Requests.Queries;
using Core.Application.CQRS.CQRS_Course.CourseStatus.Requests.Queries;
using Core.Application.DTOs.Course.Level;
using Core.Application.DTOs.Course.Status;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<List<CourseStatusDTO>>> GetAllStatus()
        {
            var list = await _mediator.Send(new GetCourseStatusRequest());
            return Ok(list);
        }

    }
}

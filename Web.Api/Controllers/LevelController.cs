using Core.Application.CQRS.CQRS_Course.CourseLevel.Requests.Queries;
using Core.Application.DTOs.Course.Level;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LevelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LevelController>
        [HttpGet]
        public async Task<ActionResult<List<CourseLevelDTO>>> GetAllLevel()
        {
            var list = await _mediator.Send(new GetCourseLevelRequest());
            return Ok(list);    
        }
       
    }
}

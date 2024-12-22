using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.CourseEpisode.Requests.Queries;
using Core.Application.CQRS.CQRS_Course.CourseStatus.Requests.Queries;
using Core.Application.DTOs.Course.Course;
using Core.Application.DTOs.Course.Episod;
using Core.Application.DTOs.Course.Status;
using Core.Domain.Entities.Ent_Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public class createEpisodeInfo
        {
            public IFormFile? episodeFile { get; set; }
            public CreateEpisodeDTO createEpisodeDTO { get; set; }
        }

        public class UpdateEpisodeInfo
        {
            public IFormFile? episodeFile { get; set; }
            public UpdateEpisodeDTO updateEpisodeDTO { get; set; }
        }

        public EpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<EpisodeController>
        [HttpGet("GetEpisodeByCourseId/{id}")]
        public async Task<ActionResult<List<EpisodeDTO>>> GetEpisodeByCourseId(int id)
        {
            var list = await _mediator.Send(new GetEpisodeByCourseIdRequest { CourseId = id });
            return Ok(list);
        }

        //GET api/<EpisodeController>/5
        [HttpGet("GetEpisodeById/{id}")]
        public async Task<ActionResult<EpisodeDTO>> GetEpisodeById(int id)
        {
            var episode = await _mediator.Send(new GetEpisodeByIdRequest { id = id });
            return Ok(episode);
        }

        // POST api/<EpisodeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] createEpisodeInfo createEpisodeInfo    )    
        {
            var episodeDTO = createEpisodeInfo.createEpisodeDTO;
            var episodeFile = createEpisodeInfo.episodeFile;

           
            if (episodeFile != null)
                episodeDTO.EpisodeFileExtention = Path.GetExtension(episodeFile.FileName);

            var command = new CreateEpisodRequest { createEpisodeDTO = episodeDTO };
            var response_id = await _mediator.Send(command);


            var episodeFolderPath = "wwwroot/course/course_" + episodeDTO.CourseId + "/EpisodeFolder";

            if (!Directory.Exists(episodeFolderPath))
                Directory.CreateDirectory(episodeFolderPath);

            if (episodeFile != null)
            {
                var EpisodeFileName = "episode_" + response_id + "." + episodeDTO.EpisodeFileExtention;
                string episodePath = Path.Combine(Directory.GetCurrentDirectory(), episodeFolderPath, EpisodeFileName);
                using (var stream = new FileStream(episodePath, FileMode.Create))
                    episodeFile.CopyTo(stream);
            }
            //-------------------------------
            return Ok(response_id);

        }

        // PUT api/<EpisodeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateEpisodeInfo updateEpisodeInfo)
        {

            var episodeDTO = updateEpisodeInfo.updateEpisodeDTO;
            var episodeFile = updateEpisodeInfo.episodeFile;


            if (episodeFile  != null)
            {
                var episodeFolderPath = "wwwroot/course/course_" + episodeDTO.CourseId + "/EpisodeFolder/episode_" +id +".*";

                if (System.IO.File.Exists(episodeFolderPath))
                    System.IO.File.Delete(episodeFolderPath);

                var EpisodeFileName = "episode_" + id + "." + episodeDTO.EpisodeFileExtention;
                string episodePath = Path.Combine(Directory.GetCurrentDirectory(), episodeFolderPath, EpisodeFileName);
               
                using (var stream = new FileStream(episodePath, FileMode.Create))
                    episodeFile.CopyTo(stream);
            }

            var command = new UpdateEpisodRequest {  UpdateEpisodeDTO= episodeDTO };
            var response = await _mediator.Send(command);
            return Ok(response);


        }

        // DELETE api/<EpisodeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {

            var episode = await _mediator.Send(new GetEpisodeByIdRequest { id = id });

            var episodeFolderPath = "wwwroot/course/course_" + episode.CourseId + "/EpisodeFolder/episode_" + id + ".*";

            if (System.IO.File.Exists(episodeFolderPath))
                System.IO.File.Delete(episodeFolderPath);

            var command = new DeleteEpisodRequest { id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}

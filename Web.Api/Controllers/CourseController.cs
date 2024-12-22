using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Queries;
using Core.Application.DTOs.Course.Course;
using Core.Application.Utilities.Convertors;
using Core.Application.Utilities.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        public class createCourseInfo
        {
            public IFormFile? ImageFile { get; set; }
            public IFormFile? Demofile { get; set; }
            public CreateCourseDTO createCourseDTO { get; set; }
        }

        public class updateCourseInfo
        {
            public IFormFile? ImageFile { get; set; }
            public IFormFile? Demofile { get; set; }
            public UpdateCourseDTO UpdateCourseDTO { get; set; }
        }

        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> GetAllCourse()
        {
            var list = await _mediator.Send(new GetCourseRequest());
            return Ok(list);
        }

        // GET api/<CourseController>/5
        [HttpGet("GetCourseById/{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
        {
            var list = await _mediator.Send(new GetCourseByIdRequest { Id = id });
            return Ok(list);
        }

        [HttpGet("GetCourseByGroupId/{id}")]
        public async Task<ActionResult<List<CourseDTO>>> GetCourseByGroupId(int id)
        {
            var list = await _mediator.Send(new GetCourseByGroupIdRequest { GroupId = id });
            return Ok(list);
        }

        //[HttpGet("{Id}")]
        //[ActionName("GetCourseByTeacherId")]
        //public async Task<ActionResult<List<CourseDTO>>> GetCourseByTeacherId(int id)
        //{
        //    var list = await _mediator.Send(new GetCourseByTeacherIdRequest { TeacherId = id });
        //    return Ok(list);
        //}

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] createCourseInfo courseInfo)
        {
            //----------------------------
            var course = courseInfo.createCourseDTO;
            var imgCourse = courseInfo.ImageFile;
            var demoCourse = courseInfo.Demofile;

            if (imgCourse != null && imgCourse.IsImage())
                course.CourseImageExtention = Path.GetExtension(imgCourse.FileName);

            if (demoCourse != null)
                course.DemoFileExtention = Path.GetExtension(demoCourse.FileName);

            var command = new CreateCourseRequest { courseDTO = course };
            var response_id = await _mediator.Send(command);


            var courseFolderPath = "wwwroot/course/course_" + response_id;

            if (!Directory.Exists(courseFolderPath))
                Directory.CreateDirectory(courseFolderPath);

            //TODO Check Image

            if (imgCourse != null && imgCourse.IsImage())
            {
                var ImageName = "img_" + response_id + "." + course.CourseImageExtention;
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), courseFolderPath, ImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                    imgCourse.CopyTo(stream);
                //-----------thumb
                var thumbName = "thumb_" + response_id + "." + course.CourseImageExtention;
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), courseFolderPath, thumbName);
                imgResizer.Image_resize(imagePath, thumbPath, 250);
            }


            if (demoCourse != null)
            {
                var DemoFileName = "Demo_" + response_id + "." + course.DemoFileExtention;
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), courseFolderPath, DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                    demoCourse.CopyTo(stream);
            }
            //-------------------------------
            return Ok(response_id);
        }


        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] updateCourseInfo courseInfo)
        {

            var newCourse = courseInfo.UpdateCourseDTO;
            var new_imgCourse = courseInfo.ImageFile;
            var new_demoCourse = courseInfo.Demofile;
            //----------------------------------------------

            if (new_imgCourse != null && new_imgCourse.IsImage())
            {
                string OldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "img_" + id + ".*");
                string OldThumbePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "thumb_" + id + ".*");

                if (System.IO.File.Exists(OldImagePath))
                    System.IO.File.Delete(OldImagePath);


                if (System.IO.File.Exists(OldThumbePath))
                    System.IO.File.Delete(OldThumbePath);
               
                newCourse.CourseImageExtention = Path.GetExtension(new_imgCourse.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "img_" + id + "." + newCourse.CourseImageExtention);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                    new_imgCourse.CopyTo(stream);

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "thumb_" + id + "." + newCourse.CourseImageExtention);
                imgResizer.Image_resize(imagePath, thumbPath, 250);
            }

            if (new_demoCourse != null)
            {
                newCourse.DemoFileExtention = Path.GetExtension(new_imgCourse.FileName);
                string new_demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "demo_" + id + "." + newCourse.DemoFileExtention);
                string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "demo_" + id + ".*");

                if (System.IO.File.Exists(deleteDemoPath))
                    System.IO.File.Delete(deleteDemoPath);

                using (var stream = new FileStream(new_demoPath, FileMode.Create))
                    new_demoCourse.CopyTo(stream);
            }
            //-----------------------------------------------
            var command = new UpdateCourseRequest { courseDTO = newCourse };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            string OldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "img_" + id + ".*");
            string OldThumbePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "thumb_" + id + ".*");

            if (System.IO.File.Exists(OldImagePath))
                System.IO.File.Delete(OldImagePath);


            if (System.IO.File.Exists(OldThumbePath))
                System.IO.File.Delete(OldThumbePath);


            string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/course/course_" + id, "demo_" + id + ".*");

            if (System.IO.File.Exists(deleteDemoPath))
                System.IO.File.Delete(deleteDemoPath);

            Directory.Delete("wwwroot/course/course_" + id,true);

            //---------------------------------------------------

            var command = new DeleteCourseRequest { id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

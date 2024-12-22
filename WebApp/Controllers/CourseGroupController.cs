using AutoMapper;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Commands;
using Core.Domain.Entities.Ent_Course;
using Microsoft.AspNetCore.Mvc;
using WebApp.Contracts.IService_Course;
using WebApp.Models.CourseViewModels.CourseGroupViewModel;
using WebApp.Services.Base;

namespace WebApp.Controllers
{
    public class CourseGroupController : Controller
    {

        private readonly ICourseGroupService _courseGroupService;
        private readonly IMapper _mapper;

        public CourseGroupController(ICourseGroupService courseGroupService,IMapper mapper)
        {
            _courseGroupService = courseGroupService;
            _mapper=mapper;
        }

        public async Task<IActionResult>  Index()
        {
            var groupList = await _courseGroupService.GetAll();
            return View(groupList);
        }

        [HttpGet]
        public async Task<IActionResult> EditGroup(int groupId)
        {
            var groupItem = await _courseGroupService.Get(groupId);
            if (groupItem == null)
                return NotFound();
            return View("EditGroup", groupItem);

        }

        [HttpPost]
        public async Task<IActionResult> EditGroup(CourseGroupVM courseGroupVM)
        {
            try
            {
               var response = await _courseGroupService.UpdateCourseGroup(courseGroupVM);
                if (response.Success)
                {
                    return Redirect($"/CourseGroup/Index");
                }
                ModelState.AddModelError("",response.ValidationErrors ?? " ValidationErrors is null");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            return View(courseGroupVM);
          

        }
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var groupItem = await _courseGroupService.Get(groupId);
            if (groupItem == null)
                return NotFound();
            return View("DeleteGroup", groupItem);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(CourseGroupVM courseGroupVM)
        {
            try
            {
                var response = await _courseGroupService.DeleteCourseGroup(courseGroupVM.GroupId);
                if (response.Success)
                {
                    return Redirect($"/CourseGroup/Index");
                }
                ModelState.AddModelError("", response.ValidationErrors ?? " ValidationErrors is null");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Redirect($"/CourseGroup/Index");
        }


    }
}

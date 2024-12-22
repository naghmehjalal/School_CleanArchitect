using Core.Application.Responses;
using MediatR;
using WebApp.Models.CourseViewModels.CourseGroupViewModel;
using WebApp.Services.Base;

namespace WebApp.Contracts.IService_Course
{
    public interface ICourseGroupService
    {
        Task<List<CourseGroupVM>> GetAll();
        Task<CourseGroupVM> Get(int id);
        Task<List<CourseGroupVM>> GetSubGroup(int parentId);
        Task<Response<int>> CreateCourseGroup(CreateCourseGroupVM createCourseGroup);
        Task<Response<int>> UpdateCourseGroup(CourseGroupVM courseGroup);
        Task<Response<int>> DeleteCourseGroup(int id);
    }
}

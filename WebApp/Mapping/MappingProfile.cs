using AutoMapper;
using WebApp.Services.Base;
using WebApp.Models.CourseViewModels.CourseGroupViewModel;
namespace WebApp.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateCourseGroupDTO, CreateCourseGroupVM>().ReverseMap();
            CreateMap<CourseGroupDTO, CourseGroupVM>().ReverseMap();
            CreateMap<UpdateCourseGroupDTO, UpdateCourseGroupVM>().ReverseMap();
            CreateMap<UpdateCourseGroupDTO, CourseGroupVM>().ReverseMap();
        }

    }
}

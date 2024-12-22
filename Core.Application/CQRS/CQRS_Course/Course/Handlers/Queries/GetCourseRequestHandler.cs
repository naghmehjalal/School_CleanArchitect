using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Course.Requests.Queries;
using Core.Application.DTOs.Course.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.Course.Handlers.Queries
{
    public class GetCourseRequestHandler : IRequestHandler<GetCourseRequest, List<CourseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _course ;
        public GetCourseRequestHandler(ICourseRepository course,IMapper mapper)
        {
            _course= course;
            _mapper= mapper;
        }


        public async Task<List<CourseDTO>> Handle(GetCourseRequest request, CancellationToken cancellationToken)
        {
            var courseList = await _course.GetAllAsync();
            return _mapper.Map<List<CourseDTO>>(courseList);
        }
    }
}

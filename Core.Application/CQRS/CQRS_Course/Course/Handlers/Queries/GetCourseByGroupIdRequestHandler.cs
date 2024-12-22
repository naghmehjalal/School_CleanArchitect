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
    public class GetCourseByGroupIdRequestHandler : IRequestHandler<GetCourseByGroupIdRequest, List<CourseDTO>>
    {

        private readonly IMapper _mapper;
        private readonly ICourseRepository _course;
        public GetCourseByGroupIdRequestHandler(ICourseRepository course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        public async Task<List<CourseDTO>> Handle(GetCourseByGroupIdRequest request, CancellationToken cancellationToken)
        {
            //TODO
            
            var courseOBJ = await _course.GetCourseByGroupId(request.GroupId);
            return _mapper.Map<List<CourseDTO>>(courseOBJ);
        }
    }
}

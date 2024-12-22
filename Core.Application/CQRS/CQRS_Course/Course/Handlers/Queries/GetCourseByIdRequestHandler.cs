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
    public class GetCourseByIdRequestHandler : IRequestHandler<GetCourseByIdRequest, CourseDTO>
    {

        private readonly IMapper _mapper;
        private readonly ICourseRepository _course;
        public GetCourseByIdRequestHandler(ICourseRepository course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        public async Task<CourseDTO> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var courseOBJ = await _course.GetAsync(request.Id);
            return _mapper.Map<CourseDTO>(courseOBJ);
        }
    
    }
}

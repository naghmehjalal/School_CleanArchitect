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
    public class GetCourseByTeacherIdRequestHandler : IRequestHandler<GetCourseByTeacherIdRequest, List<CourseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _course;
        public GetCourseByTeacherIdRequestHandler(ICourseRepository course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }


        public Task<List<CourseDTO>> Handle(GetCourseByTeacherIdRequest request, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}

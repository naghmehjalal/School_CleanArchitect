using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseStatus.Requests.Queries;
using Core.Application.DTOs.Course.Status;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseStatus.Handlers.Queries
{
    public class GetCourseStatusRequestHandlers : IRequestHandler<GetCourseStatusRequest, List<CourseStatusDTO>>
    {
        private readonly ICourseStatusRepository _courseStatus;
        private readonly IMapper _mapper;

        public GetCourseStatusRequestHandlers(ICourseStatusRepository courseStatus, IMapper mapper)
        {
            _courseStatus = courseStatus;
            _mapper = mapper;
        }


        public async Task<List<CourseStatusDTO>> Handle(GetCourseStatusRequest request, CancellationToken cancellationToken)
        {
            var list = await _courseStatus.GetAllAsync();
            return _mapper.Map<List<CourseStatusDTO>>(list);
        }
    }
}

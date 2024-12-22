using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Queries;
using Core.Application.DTOs.Course.Group;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseGroup.Handlers.Queries
{
    public class GetGroupByIdRequestHandler : IRequestHandler<GetGroupByIdRequest,CourseGroupDTO>
    {

        private readonly IMapper _mapper;
        private readonly ICourseGroupRepository _courseGroupRepository;

        public GetGroupByIdRequestHandler(ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseGroupRepository = courseGroupRepository;
        }

        public async Task<CourseGroupDTO> Handle(GetGroupByIdRequest request, CancellationToken cancellationToken)
        {
            var obj = await _courseGroupRepository.GetAsync(request.Id);
            return _mapper.Map<CourseGroupDTO>(obj);
        }
    }
}

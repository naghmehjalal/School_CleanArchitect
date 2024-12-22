using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Queries;
using Core.Application.DTOs.Course.Group;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Handlers.Queries
{
    public class GetGroupsRequestHandler : IRequestHandler<GetGroupsRequest, List<CourseGroupDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseGroupRepository _courseGroupRepository;

        public GetGroupsRequestHandler(ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseGroupRepository = courseGroupRepository;
        }
        public async Task<List<CourseGroupDTO>> Handle(GetGroupsRequest request, CancellationToken cancellationToken)
        {

            var list = await _courseGroupRepository.GetAllAsync();
            return _mapper.Map<List<CourseGroupDTO>>(list);
        }
    }
}

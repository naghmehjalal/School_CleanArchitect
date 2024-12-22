using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.CourseLevel.Requests.Queries;
using Core.Application.DTOs.Course.Level;
using Core.Domain.Entities.Ent_Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.CourseLevel.Handlers.Queries
{
    public class GetCourseLevelRequestHandler : IRequestHandler<GetCourseLevelRequest, List<CourseLevelDTO>>
    {

        private readonly ICourseLevelRepository _courseLevel;
        private readonly IMapper _mapper;
        public GetCourseLevelRequestHandler(ICourseLevelRepository courseLevel, IMapper mapper)
        {
            _courseLevel = courseLevel;
            _mapper = mapper;
        }

        public async Task<List<CourseLevelDTO>> Handle(GetCourseLevelRequest request, CancellationToken cancellationToken)
        {
            var list = await _courseLevel.GetAllAsync();
            return _mapper.Map<List<CourseLevelDTO>>(list);
        }
    }
}

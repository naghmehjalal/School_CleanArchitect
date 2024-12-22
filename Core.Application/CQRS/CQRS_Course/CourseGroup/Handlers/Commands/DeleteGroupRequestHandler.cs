using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Course.Group.Handlers.Commands
{
    public class DeleteGroupRequestHandler : IRequestHandler<DeleteGroupRequest,Unit>
    {


        private readonly IMapper _mapper;
        private readonly ICourseGroupRepository _courseGroupRepository;
        public DeleteGroupRequestHandler
            (ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }
                
        public  async Task<Unit> Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
        {
            var GroupOBJ = await _courseGroupRepository.GetAsync(request.groupId);
            await _courseGroupRepository.DeleteAsync(GroupOBJ);
            return Unit.Value;
        }
    }
}

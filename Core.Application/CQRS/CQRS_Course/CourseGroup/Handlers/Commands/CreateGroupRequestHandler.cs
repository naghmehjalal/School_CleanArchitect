using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Commands;
using Core.Application.DTOs.Course.Group.Validators;
using Core.Application.Exceptions;
using MediatR;
using Core.Domain.Entities.Ent_Course;
using Core.Application.Responses;

namespace Core.Application.CQRS.CQRS_Course.Group.Handlers.Commands
{
    public class CreateGroupRequestHandler : IRequestHandler<CreateGroupRequest, BaseCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly ICourseGroupRepository _courseGroupRepository;
        public CreateGroupRequestHandler
            (ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGroupDTOValidator();
            var validationResult = await validator.ValidateAsync(request.groupDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var newGroup = _mapper.Map<Core.Domain.Entities.Ent_Course.CourseGroup>(request.groupDTO);
                newGroup = await _courseGroupRepository.AddAsync(newGroup);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = newGroup.GroupId;
            }
            return response;
        }
    }
}

using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.CQRS.CQRS_Course.Group.Requests.Commands;
using Core.Application.DTOs.Course.Group.Validators;
using Core.Application.Exceptions;
using Core.Application.Responses;
using MediatR;

namespace Core.Application.CQRS.CQRS_Course.Group.Handlers.Commands
{
    public class UpdateGroupRequestHandler : IRequestHandler<UpdateGroupRequest, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseGroupRepository _courseGroupRepository;
        public UpdateGroupRequestHandler
            (ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateGroupRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateGroupDTOValidator();
            var validationResult = await validator.ValidateAsync(request.groupDTO);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var groupOBJ = await _courseGroupRepository.GetAsync(request.groupDTO.GroupId);
                _mapper.Map(request.groupDTO, groupOBJ);
                await _courseGroupRepository.UpdateAsync(groupOBJ);

                response.Success = true;
                response.Message = "Update Successful";
                response.Id = groupOBJ.GroupId;
            }
            return response;
        }
    }
}

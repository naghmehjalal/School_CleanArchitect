using AutoMapper;
using Core.Application.Responses;
using MediatR;
using WebApp.Contracts;
using WebApp.Contracts.IService_Course;
using WebApp.Models.CourseViewModels.CourseGroupViewModel;
using WebApp.Services.Base;

namespace WebApp.Services.Service_Course
{
    public class CourseGroupService : BaseHttpService, ICourseGroupService
    {
        private readonly IMapper mapper;
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public CourseGroupService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService)
            : base(httpClient, localStorageService)
        {
            this.mapper = mapper;
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;

        }

        public async Task<Response<int>> CreateCourseGroup(CreateCourseGroupVM createCourseGroup)
        {
            try
            {
                var response = new Response<int>();
                CreateCourseGroupDTO createGroupDTO = mapper.Map<CreateCourseGroupDTO>(createCourseGroup);
                var apiResponse = await _client.CourseGroupPOSTAsync(createGroupDTO);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in apiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;

            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteCourseGroup(int id)
        {
            try
            {
                await _client.CourseGroupDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> UpdateCourseGroup(CourseGroupVM courseGroup)
        {
            var response = new Response<int>();
            UpdateCourseGroupDTO updateCourseGroupDTO = mapper.Map<UpdateCourseGroupDTO>(courseGroup);

            try
            {
                await _client.CourseGroupPUTAsync(updateCourseGroupDTO.GroupId, updateCourseGroupDTO);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<CourseGroupVM> Get(int id)
        {
            var obj = await _client.GetGroupByIdAsync(id);
            return mapper.Map<CourseGroupVM>(obj);
        }

        public async Task<List<CourseGroupVM>> GetAll()
        {
            var list = await _client.GetAllGroupAsync();
            return mapper.Map<List<CourseGroupVM>>(list);
        }

        public async Task<List<CourseGroupVM>> GetSubGroup(int parentId)
        {
            var list = await _client.GetSubGroupAsync(parentId);
            return mapper.Map<List<CourseGroupVM>>(list);

        }

    }
}
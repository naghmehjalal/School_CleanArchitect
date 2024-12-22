using Core.Application.Contracts.Persistence.Interface_Course;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities.Ent_Course;
using AutoMapper;

namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class Courserepository : GenericRepository<Course>, ICourseRepository
    {

        private readonly AppContext _dbcontext;
        private readonly IMapper _mapper;

        public Courserepository(AppContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public Task<List<Course>> GetCourseByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}


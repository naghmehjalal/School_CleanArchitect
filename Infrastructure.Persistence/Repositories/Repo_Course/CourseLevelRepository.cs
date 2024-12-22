using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Domain.Entities.Ent_Course;

namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class CourseLevelRepository : GenericRepository<CourseLevel>, ICourseLevelRepository
    {
        private readonly AppContext _dbcontext;
        public CourseLevelRepository(AppContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }
    }
}

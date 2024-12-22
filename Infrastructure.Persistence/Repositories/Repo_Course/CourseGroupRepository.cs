using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.DTOs.Course.Group;
using Core.Domain.Entities.Ent_Course;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class CourseGroupRepository : GenericRepository<CourseGroup>, ICourseGroupRepository
    {
        private readonly AppContext _dbContext ;

        public CourseGroupRepository(AppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<List<CourseGroup>> GetSubdGroup(int parentId)
        {
            return await  _dbContext.CourseGroups.Where( p => p.ParentId==parentId).ToListAsync();

        }


    }
}

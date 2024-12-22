using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Domain.Entities.Ent_Course;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class CourseStatusRepository:GenericRepository<CourseStatus>, ICourseStatusRepository
    {
        private readonly AppContext _dbcontext;
        public CourseStatusRepository(AppContext dbContext)
           : base(dbContext)
        {
            _dbcontext = dbContext;
        }
    }
}

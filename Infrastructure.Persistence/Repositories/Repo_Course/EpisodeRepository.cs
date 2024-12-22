using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Domain.Entities.Ent_Course;

namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        private readonly AppContext _dbcontext;
        public EpisodeRepository(AppContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;
        }

    }
}

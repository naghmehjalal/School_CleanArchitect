using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.DTOs.Course.Comment;
using Core.Domain.Entities.Ent_Course;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Repo_Course
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {

        private readonly AppContext _dbcontext;
        private readonly IMapper _mapper;

        public CommentRepository(AppContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

       
        public async Task<List<CommentDTO>> GetByCourseId(int Courseid)
        {
            var list = await _dbcontext.Comments
                .Include(c => c.Course)
                .Include(c => c.User)
                .Where(c => c.CourseId == Courseid)
                .OrderByDescending(c => c.DateCreated)
                 .Select(c => new CommentDTO()
                 {
                     CommentId = c.CourseId,
                     CourseId = c.CourseId,
                     Comment=c.Comment_Text,
                     IsAdminRead=c.IsAdminRead,
                     CourseTitle = c.Course.CourseTitle,
                     UserId= c.comment_UserId,
                     FullUserName= c.User.FirstName +" "+ c.User.LastName,
                     Created=c.DateCreated
                 })
                .ToListAsync();

            return _mapper.Map<List<CommentDTO>>(list);

        }
    }
}

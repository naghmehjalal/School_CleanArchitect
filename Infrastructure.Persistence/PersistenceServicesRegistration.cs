using Core.Application.Contracts.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Repositories.Repo_Course;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Infrastructure.Persistence.Repositories.Repo_Wallet;

namespace Infrastructure.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
                   IConfiguration configuration)
        {
            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("AppConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICourseRepository,Courserepository>();
            services.AddScoped<ICourseGroupRepository, CourseGroupRepository>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICourseLevelRepository, CourseLevelRepository>();
            services.AddScoped<ICourseStatusRepository, CourseStatusRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            //----------------------------------------------------------------
            services.AddScoped<IWalletRepository, WalletRepository>();


            return services;
        }
    }
}

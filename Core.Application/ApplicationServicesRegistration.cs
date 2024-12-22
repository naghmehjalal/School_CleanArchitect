using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application
{
    public static class ApplicationServicesRegistration
    {

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(o =>
            //{
            //    o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            //});
        }
    }
}


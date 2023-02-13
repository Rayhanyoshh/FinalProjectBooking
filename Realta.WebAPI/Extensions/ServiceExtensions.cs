using Realta.Domain.Base;
using Realta.Persistence.Base;
using Realta.Persistence.RepositoryContext;
using Realta.Services;
using Realta.Services.Abstraction;

namespace Realta.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy", builder =>
                   builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
           });

        // add IIS configure options deploy to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        //create a service once per request
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddSingleton(new AdoDbContext(configuration.GetConnectionString("development")));

    }
}

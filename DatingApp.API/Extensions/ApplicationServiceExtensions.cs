using DatingApp.API.Database;
using DatingApp.API.Database.Repositories;
using DatingApp.API.Profiles;
using DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            // Init Database using MySQL
            // "DefaultConnection": "server=localhost;user=root;password=YourPassword;database=UserDb"
            // services.AddDbContext<DataContext>(options =>
            //     options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)))
            //     .EnableSensitiveDataLogging() // <-- These two calls are optional but help
            //     .EnableDetailedErrors()       // <-- with debugging (remove for production).
            // );

            return services;
        }
    }
}
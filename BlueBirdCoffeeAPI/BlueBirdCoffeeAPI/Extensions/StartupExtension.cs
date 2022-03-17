using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Service.Services;

namespace BlueBirdCoffeeAPI.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigIdentityDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        }

        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFloorService, FloorService>();
        }

        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                      builder =>
                      {
                          builder
                                 //.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .SetIsOriginAllowed((host) => true)
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                      });
            });
        }
    }
}

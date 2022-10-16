using Data.DataAccessLayer;
using Data.Entities;
using Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Services;

namespace BlueBirdCoffeeAPI.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigIdentityDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
            })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
        }

        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<ITableHub, TableHub>();
            services.AddSingleton<INotificationHub, NotificationHub>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IBillService, BillService>();
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

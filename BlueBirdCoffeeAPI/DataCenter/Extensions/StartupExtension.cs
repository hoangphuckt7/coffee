using Data.DataAccessLayer;
using Data.Entities;
using DataCenter.DataAccess;
using DataCenter.Services;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace DataCenter.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigIdentityDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            string connectionString = "";
            try
            {
                connectionString = EnvironmentHelper.GetValue("ConnectionString");
            }
            catch (Exception)
            {
                connectionString = configuration.GetConnectionString("BlueBirdCoffeeDatabase");
            }

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

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions
                {
                    SchemaName = "hangfire"
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }

        public static void ConfigMongoDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            string connectionString = "";
            try
            {
                connectionString = EnvironmentHelper.GetValue("MongoConnectionString");
            }
            catch (Exception)
            {
                connectionString = configuration["AppDatabaseSettings:ConnectionString"];
            }

            string databaseName = "";
            try
            {
                databaseName = EnvironmentHelper.GetValue("MongoDbName");
            }
            catch (Exception)
            {
                databaseName = configuration["AppDatabaseSettings:DatabaseName"];
            }

            services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));
            services.AddScoped(s => new MongoDbContext(s.GetRequiredService<IMongoClient>(), databaseName));
        }

        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBackupService, BackupService>();
            services.AddScoped<IRestoreService, RestoreService>();
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

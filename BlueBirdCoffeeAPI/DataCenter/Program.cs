using Data.DataAccessLayer;
using DataCenter.DataAccess;
using DataCenter.Extensions;
using DataCenter.MapperProfiles;
using DataCenter.Services;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigCors();
builder.Services.ConfigJwt(configuration);
builder.Services.ConfigIdentityDbContext(configuration);
builder.Services.ConfigMongoDbContext(configuration);
builder.Services.AddSwaggerWithAuthentication("Blue Bird Coffee Data Center", "v1.0");
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.BusinessServices();

#region setup application settings
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
builder.Services.BuildServiceProvider().GetService<MongoDbContext>().CreateCollectionsIfNotExists();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

TimeZoneInfo hanoiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
RecurringJob.AddOrUpdate<IBackupService>("BackupAllData", context => context.BackupAllData(), "0 0 11,21 * * ?", hanoiTimeZone);

app.Run();

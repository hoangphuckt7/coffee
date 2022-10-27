using BlueBirdCoffeeAPI.Extensions;
using Hubs;
using Microsoft.OpenApi.Models;
using Service.MapperProfiles;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers((opt) => opt.Filters.Add<ExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigCors();
builder.Services.ConfigJwt(configuration);
builder.Services.AddSwaggerWithAuthentication("Blue Bird Coffee API", "v1.0");

#region Get connection string - setup db
string connectionString = "";
try
{
    connectionString = EnvironmentHelper.GetValue("ConnectionString");
}
catch (Exception)
{
    connectionString = configuration.GetConnectionString("BlueBirdCoffeeDatabase");
}
#endregion

builder.Services.ConfigIdentityDbContext(connectionString);
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.BusinessServices();
builder.Services.AddSignalR();

#region setup application settings
try
{
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
    builder.Services.BuildServiceProvider().GetService<ISettingService>().SetupSettings();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
}
catch (Exception) { }
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");
app.MapHub<TableHub>("/tableHub");

app.Run();

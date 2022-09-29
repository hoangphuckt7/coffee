using BlueBirdCoffeeAPI.Extensions;
using Hubs;
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
builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Blue Bird Coffee API", Version = "v1.0" }));
builder.Services.ConfigIdentityDbContext(configuration.GetConnectionString("BlueBirdCoffeeDatabase"));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.BusinessServices();
builder.Services.AddSignalR();
//builder.Services.BuildServiceProvider().GetService<ISettingService>().SetupSettings();

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

global using TestProject.Data;
global using TestProject.Infrastructure.Interfaces;
global using TestProject.Infrastructure.Repositories;
global using TestProject.Domain.Logger;
global using TestProject.Domain.Mapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    logger.Info("Test Project is starting up ");
    ConfigurationManager configuration = builder.Configuration;
    builder.Services.AddControllers();
    builder.Services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<ILoggerManager, LoggerManager>();
    builder.Services.AddScoped<IPaginationRepo, PaginationRepo>();
    builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
    builder.Services.AddAutoMapper(typeof(TestMapper));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
        });
    });
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors();
    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
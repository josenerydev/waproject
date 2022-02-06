using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

using Serilog;

using waproject.Application;
using waproject.Data;
using waproject.Data.Contexts;
using waproject.Identity;
using waproject.Identity.Contexts;
using waproject.WebApi.Extensions;

var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{envName}.json", optional: true)
  .AddEnvironmentVariables()
  .AddUserSecrets(typeof(Program).Assembly, optional: true)
  .AddCommandLine(args)
  .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddApplication(configuration);
builder.Services.AddInfrastructureData(configuration);
builder.Services.AddInfrastructureIdentity(configuration);
builder.Services.AddAuthenticationExtension(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddVersionedApiExplorerExtension();
builder.Services.AddSwaggerGenExtension();
builder.Services.AddCors();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExtension(apiVersionDescriptionProvider);
}

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Starting web host");

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var appContext = services.GetRequiredService<ApplicationDbContext>();
        var authContext = services.GetRequiredService<AuthDbContext>();
        await appContext.Database.MigrateAsync();
        await authContext.Database.MigrateAsync();
        if (!app.Environment.IsProduction())
        {
            await waproject.Data.SeedData.Initialize(appContext);
            await waproject.Identity.SeedData.Initialize(services);
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
        throw;
    }

    await app.RunAsync();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}


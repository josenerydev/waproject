using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using waproject.Application.Common.Interfaces;
using waproject.Data.Contexts;

namespace waproject.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services, IConfiguration configuration)
        {
            bool.TryParse(configuration.GetSection("EnableSensitiveDataLogging").Value, out bool enableSensitiveDataLogging);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging(enableSensitiveDataLogging));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
            return services;
        }
    }
}

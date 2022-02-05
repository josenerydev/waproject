using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });


            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
            return services;
        }
    }
}

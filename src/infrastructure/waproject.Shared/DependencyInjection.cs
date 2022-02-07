using Microsoft.Extensions.DependencyInjection;

using waproject.Application.Common.Interfaces;
using waproject.Shared.Services;

namespace waproject.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureShared(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}

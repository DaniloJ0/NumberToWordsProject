using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NumberToWords.Domain.Models.Jwt;
using NumberToWords.Infrastructure.Services;

namespace NumberToWords.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}

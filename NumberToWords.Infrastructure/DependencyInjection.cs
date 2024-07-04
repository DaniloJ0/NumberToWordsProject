using ContactManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NumberToWords.Domain.Models.User;

namespace ContactManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string not found")));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

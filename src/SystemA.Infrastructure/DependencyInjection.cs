using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SystemA.Application.Repositories;
using SystemA.Infrastructure.Data;
using SystemA.Infrastructure.Repositories;

namespace SystemA.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SystemADbContext>(options =>
            options.UseSqlServer(connectionString));

            services.RegisterRepositories();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

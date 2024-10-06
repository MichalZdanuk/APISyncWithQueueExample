using Microsoft.Extensions.DependencyInjection;
using SystemA.Contracts.Events.Users;
using SystemB.Application.Events.External.Users;
using SystemB.Application.Events;

namespace SystemB.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEventHandler<UserCreatedEvent>, UserCreatedEventHandler>();
            services.AddScoped<IEventHandler<UserUpdatedEvent>, UserUpdatedEventHandler>();
        }
    }
}

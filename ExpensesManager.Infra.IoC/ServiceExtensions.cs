using Microsoft.Extensions.DependencyInjection;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Token;
using ExpensesManager.Application.Services.User;

namespace ExpensesManager.Infra.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenServiceApplication, TokenServiceApplication>();
            services.AddScoped<IUserServiceApplication, UserServiceApplication>();

            return services;
        }
    }
}
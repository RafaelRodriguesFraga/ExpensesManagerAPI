using Microsoft.Extensions.DependencyInjection;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Token;
using ExpensesManager.Application.Services.User;
using ExpensesManager.Application.Services.Expense;
using ExpensesManager.Application.Services.Person;
using ExpensesManager.Application.Services.Auth;

namespace ExpensesManager.Infra.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenServiceApplication, TokenServiceApplication>();
            services.AddScoped<IUserServiceApplication, UserServiceApplication>();
            services.AddScoped<IPersonServiceApplication, PersonServiceApplication>();
            services.AddScoped<IExpenseServiceApplication, ExpenseServiceApplication>();
            services.AddScoped<IAuthServiceApplication, AuthServiceApplication>();


            return services;
        }
    }
}
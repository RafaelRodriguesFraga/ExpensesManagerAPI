using ExpensesManager.Domain.Repositories;
using ExpensesManager.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ListaComprasApi.Infra.CrossCutting.IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();       
            services.AddScoped<IExpenseWriteRepository, ExpenseWriteRepository>(); 
            services.AddScoped<IExpenseReadRepository, ExpenseReadRepository>();        
            services.AddScoped<IMonthReadRepository, MonthReadRepository>();
            services.AddScoped<IAuthWriteRepository, AuthWriteRepository>();
            services.AddScoped<IAuthReadRepository, AuthReadRepository>();        

            return services;
        }
    }
}

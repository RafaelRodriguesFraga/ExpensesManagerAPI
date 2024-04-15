using ExpensesManager.Application.Services.Person;
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
            services.AddScoped<IPersonServiceApplication, PersonServiceApplication>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();        

            return services;
        }
    }
}

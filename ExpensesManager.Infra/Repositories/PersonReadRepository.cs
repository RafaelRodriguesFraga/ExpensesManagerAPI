using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class PersonReadRepository : BaseReadRepository<Person>, IPersonReadRepository
    {
        public PersonReadRepository(BaseContext context) : base(context)
        {
        }

        public async Task<Person> GetByNameAsync(string name)
        {
             return await Set
                .AsNoTracking()
                .Include(p => p.User)
                .Where(p => p.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}


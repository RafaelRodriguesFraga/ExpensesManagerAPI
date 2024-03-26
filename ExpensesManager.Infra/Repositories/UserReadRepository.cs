using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
using DotnetBoilerplate.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(BaseContext context) : base(context)
        {
        }

        public async Task<User> GetByEmaillAsync(string email)
        {
            return await Set
                .AsNoTracking()
                .Where(user => user.Email.Trim() == email.Trim())
                .FirstOrDefaultAsync();
        }
    }
}
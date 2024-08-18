using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class AuthReadRepository : BaseReadRepository<User>, IAuthReadRepository
    {
        public AuthReadRepository(BaseContext context) : base(context)
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
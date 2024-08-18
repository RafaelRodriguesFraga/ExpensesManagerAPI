using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class AuthWriteRepository : BaseWriteRepository<User>, IAuthWriteRepository
    {
        public AuthWriteRepository(BaseContext context) : base(context)
        {
        }

        
    }
}
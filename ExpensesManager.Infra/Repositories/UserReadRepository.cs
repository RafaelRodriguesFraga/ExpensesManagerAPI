using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
using DotnetBoilerplate.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
    {
        private readonly BaseContext _context;
        public UserReadRepository(BaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Set<User>().OrderBy(user => user.Email).ToList();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Set<User>().OrderBy(user => user.Email).ToListAsync();
        }

        public User GetByEmaill(string email)
        {
            return  _context.Set<User>()
                .AsNoTracking()
                .Where(user => user.Email.Trim() == email.Trim())
                .FirstOrDefault();
        }

        public async Task<User> GetByEmaillAsync(string email)
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .Where(user => user.Email.Trim() == email.Trim())
                .FirstOrDefaultAsync();
        }

        public User GetById(Guid guid)
        {
            return _context.Set<User>().Find(guid);
        }

        public async Task<User> GetByIdAsync(Guid guid)
        {
            return await _context.Set<User>().FindAsync(guid);
        }
    }
}
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

        public async Task<IEnumerable<Person>> GetByNameAsync(string name)
        {
             return await Set
                .AsNoTracking()
                .Include(p => p.User)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        public async Task<(IEnumerable<Person> result, int totalRecords)> GetAllAsync(Guid userId, int page, int quantityPerPage)
        {
            var skip = page == 1 ? 0 : (page - 1) * quantityPerPage;

            var totalRecords = Set.Count();

            var result = await Set
                .Where(x => x.UserId == userId)   
                .Skip(skip)
                .Take(quantityPerPage)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return (result, totalRecords);
        }
    }
}


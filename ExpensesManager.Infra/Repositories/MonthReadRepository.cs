using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Infra.Sql.Repositories.Base;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Repositories
{
    public class MonthReadRepository : BaseReadRepository<InvoiceMonth>, IMonthReadRepository
    {
        public MonthReadRepository(BaseContext context) : base(context)
        {
        }

        public async Task<InvoiceMonth> GetByCodeAsync(int monthCode)
        {
            var month = await Set
                .AsNoTracking()
                .Where(m => m.Code == monthCode)
                .FirstOrDefaultAsync();

            return month;
        }
    }
}
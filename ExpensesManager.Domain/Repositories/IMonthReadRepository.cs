using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Domain.Sql.Repositories;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories
{
    public interface IMonthReadRepository : IBaseReadRepository<InvoiceMonth>
    {
        Task<InvoiceMonth> GetByCodeAsync(int monthCode);
    }
}
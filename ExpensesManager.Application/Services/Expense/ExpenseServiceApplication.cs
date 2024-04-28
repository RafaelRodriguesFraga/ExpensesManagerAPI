using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Application.Services.Expense
{
    public class ExpenseServiceApplication : BaseServiceApplication, IExpenseServiceApplication
    {
        private readonly IExpenseWriteRepository _writeRepository;
        public ExpenseServiceApplication(NotificationContext notificationContext, IExpenseWriteRepository writeRepository) : base(notificationContext)
        {
            _writeRepository = writeRepository;
        }

        public async Task CreateAsync(ExpenseDto expenseDto)
        {
            expenseDto.Validate();
            var expenseHasErrors = expenseDto.Invalid;
            if (expenseHasErrors)
            {
                _notificationContext.AddNotifications(expenseDto.Notifications);
                return;
            }

           await _writeRepository.InsertAsync(expenseDto);

        }
    }
}
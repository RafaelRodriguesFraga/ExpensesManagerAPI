using ExpensesManager.Api.Hubs;
using ExpensesManager.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ExpensesManager.Api.Services
{
    public class SignalRNotificationService : ISignalRNotificationService
    {
        private readonly IHubContext<ExpenseHub> _hubContext;

        public SignalRNotificationService(IHubContext<ExpenseHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyExpenseUpdate(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveExpenseUpdate", message);
        }
    }
}
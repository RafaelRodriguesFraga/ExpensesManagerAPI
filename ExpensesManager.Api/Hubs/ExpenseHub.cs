using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExpensesManager.Api.Hubs
{
    public class ExpenseHub : Hub
    {
        public async Task SendExpenseUpdate(string message) 
        {
            await Clients.All.SendAsync("ReceiveExpenseUpdate", message);
        }
        
    }
}
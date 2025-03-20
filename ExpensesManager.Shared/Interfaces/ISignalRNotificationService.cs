namespace ExpensesManager.Shared.Interfaces
{
    public interface ISignalRNotificationService
    {
        Task NotifyExpenseUpdate(string message);
    }
}
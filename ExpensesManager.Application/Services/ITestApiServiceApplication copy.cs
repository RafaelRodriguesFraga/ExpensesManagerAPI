using DotnetBoilerplate.Components.Application.Base;
using DotnetBoilerplate.Components.Shared.Notifications;

namespace ExpensesManager.Application.Services
{
    public class TestApiServiceApplication : BaseServiceApplication, ITestApiServiceApplication
    {
        public TestApiServiceApplication(NotificationContext notificationContext) : base(notificationContext)
        {
        }
    }
}
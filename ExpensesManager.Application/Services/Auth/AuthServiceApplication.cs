using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.User;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Shared;
using ExpensesManager.Shared.Localization;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Application.Services.Auth
{
    public class AuthServiceApplication : BaseServiceApplication, IAuthServiceApplication
    {
        private readonly IAuthReadRepository _readRepository;
        private readonly IAuthWriteRepository _writeRepository;
        private readonly IStringLocalizer _localizer;

        public AuthServiceApplication(
            NotificationContext notificationContext,
            IAuthReadRepository readRepository,
            IAuthWriteRepository writeRepository,
            IStringLocalizerFactory localizerFactory) : base(notificationContext)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            
             var assembly = typeof(Messages).Assembly;
            _localizer = localizerFactory.Create("Localization.Messages", assembly.GetName().Name);
        }

        public async Task<UserViewModel> GetByEmaillAsync(string email)
        {
            var user = await _readRepository.GetByEmaillAsync(email);
            var userNotFound = user == null;
            if (userNotFound)
            {
                _notificationContext.AddNotification(_localizer["User"], _localizer["UserNotFound"]);
                return default!;
            }

            return user!;
        }

        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _readRepository.GetByEmaillAsync(email);
            var userNotFound = user == null;
            if (userNotFound)
            {
                _notificationContext.AddNotification(_localizer["User"], _localizer["UserNotFound"]);
                return;
            }

            user!.SetPassword(newPassword);

            await _writeRepository.UpdateAsync(user);
            
        }
    }
}
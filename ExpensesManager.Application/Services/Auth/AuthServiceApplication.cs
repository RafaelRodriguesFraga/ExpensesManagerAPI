using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.User;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Application.Services.Auth
{
    public class AuthServiceApplication : BaseServiceApplication, IAuthServiceApplication
    {
        private readonly IAuthReadRepository _readRepository;
        private readonly IAuthWriteRepository _writeRepository;
        public AuthServiceApplication(NotificationContext notificationContext, IAuthReadRepository readRepository, IAuthWriteRepository writeRepository) : base(notificationContext)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UserViewModel> GetByEmaillAsync(string email)
        {
            var user = await _readRepository.GetByEmaillAsync(email);
            var userNotFound = user == null;
            if (userNotFound)
            {
                _notificationContext.AddNotification("User", "User not found");
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
                _notificationContext.AddNotification("User", "User not found");
                return;
            }

            user!.SetPassword(newPassword);

            await _writeRepository.UpdateAsync(user);
            
        }
    }
}
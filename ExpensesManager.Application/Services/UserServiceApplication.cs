using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.Services.Interfaces;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Application.Services
{
    public class UserServiceApplication : BaseServiceApplication, IUserServiceApplication
    {
        private readonly IUserWriteRepository _writeRepository;
        private readonly IUserReadRepository _readRepository;

        public UserServiceApplication(NotificationContext notificationContext, IUserReadRepository readRepository, IUserWriteRepository writeRepository) : base(notificationContext)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task CreateUserAsync(UserRequestDto userRequestDto)
        {
            userRequestDto.Validate();
            var invalidUser = userRequestDto.Invalid;

            if (invalidUser)
            {
                _notificationContext.AddNotifications(userRequestDto.Notifications);
                return;
            }

            var emailExists = await _readRepository.GetByEmaillAsync(userRequestDto.Email) != null;

            if (emailExists)
            {
                _notificationContext.AddNotification("Email", "There is already a user with a registered email address.");
                return;
            }

            await _writeRepository.InsertAsync(userRequestDto);
        }
    }
}
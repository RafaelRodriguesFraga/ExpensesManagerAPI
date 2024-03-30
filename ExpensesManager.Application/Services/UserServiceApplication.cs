using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotnetBoilerplate.Components.Application.Base;
using DotnetBoilerplate.Components.Shared.Notifications;
using expensesManager.Application.Services;
using ExpensesManager.Application.Services.Interfaces;
using ExpensesManager.Application.ViewModels;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Application.Services
{
    public class UserServiceApplication : BaseServiceApplication, IUserServiceApplication
    {
        private readonly IUserWriteRepository _writeRepository;
        private readonly IUserReadRepository _readRepository;
        private readonly IValidator _validatorRequest;

        public UserServiceApplication(NotificationContext notificationContext, IUserReadRepository readRepository, IUserWriteRepository writeRepository, IValidator<UserRequestDto> validatorRequest) : base(notificationContext)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _validatorRequest = validatorRequest;
        }

        public async Task<UserViewModel> CreateUserAsync(UserRequestDto userRequestDto)
        {
            var context = new ValidationContext<UserRequestDto>(userRequestDto);
            var result = await _validatorRequest.ValidateAsync(context);

            var invalidData = !result.IsValid;

            if (invalidData)
            {
                result.Errors.ForEach(error => _notificationContext.AddNotification(error.PropertyName, error.ErrorMessage));
                return default;
            }

            var emailExists = await _readRepository.GetByEmaillAsync(userRequestDto.Email) != null;

            if (emailExists)
                _notificationContext.AddNotification("Email", "There is already a user with a registered email address.");

            if (_notificationContext.HasNotifications)
                return default;

            User user = userRequestDto;

            await _writeRepository.InsertAsync(user);

            return user;
        }
    }
}
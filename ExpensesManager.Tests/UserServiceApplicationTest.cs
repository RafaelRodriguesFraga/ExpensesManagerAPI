using Castle.Core.Resource;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Interfaces;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace ExpensesManager.Tests
{
    public class UserServiceApplicationTest
    {
        private readonly IUserServiceApplication _userServiceApplication;
        private readonly Mock<IUserReadRepository> _readRepositoryMock;
        private readonly Mock<IUserWriteRepository> _writeRepositoryMock;
        private readonly NotificationContext _notificationContext;

        public UserServiceApplicationTest()
        {
            _readRepositoryMock = new Mock<IUserReadRepository>();
            _writeRepositoryMock = new Mock<IUserWriteRepository>();
            _notificationContext = new NotificationContext();
            _userServiceApplication = new UserServiceApplication(_notificationContext, _readRepositoryMock.Object, _writeRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateUserAsync_Should_Return_Valid_On_Correct_User_Request()
        {
            var userRequest = new UserRequestDto
            {
                Email = "test@test.com",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            await _userServiceApplication.CreateUserAsync(userRequest);

            Assert.True(userRequest.Valid);
        }

        [Fact]
        public async Task CreateUserAsync_Should_Return_Notifications_On_Duplicate_Email_User_Request()
        {
            var existingUserEmail = "existing@example.com";

            var userRequest = new UserRequestDto
            {
                Email = existingUserEmail,
                Password = "123456",
                ConfirmPassword = "123456"
            };

            _readRepositoryMock
                .Setup(repo => repo.GetByEmaillAsync(existingUserEmail))
                .ReturnsAsync(new User(existingUserEmail, "123456"));

            await _userServiceApplication.CreateUserAsync(userRequest);

            Assert.NotEmpty(_notificationContext.Notifications);
        }
    }
}
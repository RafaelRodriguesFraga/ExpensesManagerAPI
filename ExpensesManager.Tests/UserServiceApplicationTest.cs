using Castle.Core.Resource;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Interfaces;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ExpensesManager.Tests
{
    public class UserServiceApplicationTest
    {
        private readonly IUserServiceApplication _userServiceApplication;
        private readonly Mock<IUserReadRepository> _userReadRepository;
        private readonly Mock<IUserWriteRepository> _userWriteRepository;
        private readonly ExpensesManagerContext _dbContext;
        private readonly NotificationContext _notificationContext;

        public UserServiceApplicationTest()
        {
            _userReadRepository = new Mock<IUserReadRepository>();
            _userWriteRepository = new Mock<IUserWriteRepository>();
            _notificationContext = new NotificationContext();

            var dbContextOptions = new DbContextOptionsBuilder<ExpensesManagerContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryTestDatabase")
            .Options;

            _dbContext = new ExpensesManagerContext(dbContextOptions);
            _userServiceApplication = new UserServiceApplication(_notificationContext, _userReadRepository.Object, _userWriteRepository.Object);
        }

        [Fact]
        public async Task CreateUserAsync_Should_Return_Success_On_Correct_User_Request()
        {
            var userRequest = new UserRequestDto
            {
                Email = "teste@teste.com",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            await _userServiceApplication.CreateUserAsync(userRequest);

            Assert.True(userRequest.Valid);
        }
    }
}
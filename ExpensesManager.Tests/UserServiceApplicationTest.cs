using Castle.Core.Resource;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Interfaces;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Infra.Context;
using ExpensesManager.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Moq;

namespace ExpensesManager.Tests
{
    public class UserServiceApplicationTest
    {
        private readonly IUserServiceApplication _userServiceApplication;
        private readonly Mock<IUserReadRepository> _readRepositoryMock;
        private readonly Mock<IUserWriteRepository> _writeRepositoryMock;
        private readonly ExpensesManagerContext _dbContext;
        private readonly NotificationContext _notificationContext;

        public UserServiceApplicationTest()
        {
            _readRepositoryMock = new Mock<IUserReadRepository>();
            _writeRepositoryMock = new Mock<IUserWriteRepository>();
            _notificationContext = new NotificationContext();

            var dbContextOptions = new DbContextOptionsBuilder<ExpensesManagerContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryTestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            _dbContext = new ExpensesManagerContext(dbContextOptions);
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

            _writeRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            await _userServiceApplication.CreateUserAsync(userRequest);

            Assert.True(userRequest.Valid);
        }

        [Fact]
        public async Task CreateUserAsync_Should_Return_Invalid_On_Duplicate_Email_User_Request()
        {
            var existingUserByEmail = new User("test@test.com", "123456");
            await _dbContext.AddAsync(existingUserByEmail);
            await _dbContext.SaveChangesAsync();

            var userRequest = new UserRequestDto
            {
                Email = "test@test.com",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            _readRepositoryMock.Setup(repo => repo.GetByEmaillAsync(userRequest.Email)).ReturnsAsync(It.IsAny<User>());
            _writeRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            await _userServiceApplication.CreateUserAsync(userRequest);

            Assert.NotEmpty(_notificationContext.Notifications);
            _writeRepositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<User>()), Times.Once);
            Assert.True(userRequest.Invalid);

            // -------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //var options = new DbContextOptionsBuilder<ExpensesManagerContext>()
            //    .UseInMemoryDatabase(databaseName: "TestDatabase")
            //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            //    .Options;

            //var existingUserByEmail = new User("test@test.com", "123456");
            //await _dbContext.AddAsync(existingUserByEmail);
            //await _dbContext.SaveChangesAsync();

            //var userRequest = new UserRequestDto
            //{
            //    Email = "teste@teste.com",
            //    Password = "123456",
            //    ConfirmPassword = "123456"
            //};

            //_userWriteRepository.Setup(x => x.InsertAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            //Assert.True(userRequest.Invalid);
        }
    }
}
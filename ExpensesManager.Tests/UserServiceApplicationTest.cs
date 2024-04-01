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
using Microsoft.Extensions.Options;
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
        public async Task CreateUserAsync_Should_Return_Valid_On_Correct_User_Request()
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

        [Fact]
        public async Task CreateUserAsync_Should_Return_Invalid_On_Duplicate_Email_User_Request()
        {
            // Configurando o mock para qualquer chamada de InsertAsync com qualquer instância de User
            //_userWriteRepository.Setup(x => x.InsertAsync(new User("teste@teste.com", "123456"))).Returns(Task.CompletedTask);

            //var userRequest = new UserRequestDto
            //{
            //    Email = "teste@teste.com",
            //    Password = "123456",
            //    ConfirmPassword = "123456"
            //};

            //// Chamar o método a ser testado
            //await _userServiceApplication.CreateUserAsync(userRequest);

            //// Asserção do resultado esperado
            //Assert.True(userRequest.Invalid);

            var options = new DbContextOptionsBuilder<ExpensesManagerContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var existingUserByEmail = new User("test@test.com", "123456");
            await _dbContext.AddAsync(existingUserByEmail);
            await _dbContext.SaveChangesAsync();

            var userRequest = new UserRequestDto
            {
                Email = "teste@teste.com",
                Password = "123456",
                ConfirmPassword = "123456"
            };

            _userWriteRepository.Setup(x => x.InsertAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            Assert.True(userRequest.Invalid);
        }
    }
}
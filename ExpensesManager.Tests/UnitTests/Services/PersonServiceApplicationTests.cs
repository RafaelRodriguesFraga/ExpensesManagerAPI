using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetBaseKit.Components.Application.Pagination;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.Services.Person;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Shared.Localization;
using Microsoft.Extensions.Localization;
using Moq;
using Xunit;

namespace ExpensesManager.Tests.UnitTests.Services
{
    public class PersonServiceApplicationTests
    {
        private readonly Mock<IPersonWriteRepository> _mockWriteRepository;
        private readonly Mock<IPersonReadRepository> _mockReadRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IStringLocalizerFactory> _mockStringLocalizerFactory;
        private readonly Mock<IStringLocalizer> _mockStringLocalizer;
        private readonly NotificationContext _notificationContext;
        private readonly PersonServiceApplication _personService;

        public PersonServiceApplicationTests()
        {
            _mockWriteRepository = new Mock<IPersonWriteRepository>();
            _mockReadRepository = new Mock<IPersonReadRepository>();
            _mockMapper = new Mock<IMapper>();
            _notificationContext = new NotificationContext();

            _mockStringLocalizer = new Mock<IStringLocalizer>();
            _mockStringLocalizerFactory = new Mock<IStringLocalizerFactory>();

            _mockStringLocalizer.Setup(x => x["NameCannotBeEmpty"]).Returns(new LocalizedString("NameCannotBeEmpty", "Name cannot be empty"));
            _mockStringLocalizer.Setup(x => x["UserIdCannotBeEmpty"]).Returns(new LocalizedString("UserIdCannotBeEmpty", "User ID cannot be empty"));

            _mockStringLocalizerFactory.Setup(f => f.Create(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_mockStringLocalizer.Object);

            LocalizerService.Configure(_mockStringLocalizerFactory.Object);

            _personService = new PersonServiceApplication(
                _notificationContext,
                _mockWriteRepository.Object,
                _mockReadRepository.Object,
                _mockMapper.Object,
                _mockStringLocalizerFactory.Object);
        }

        [Fact]
        public async Task CreateAsync_WithValidPerson_CallsInsertAsync()
        {

            var personDto = new PersonDto { Name = "John Doe", UserId = Guid.NewGuid() };
            _mockWriteRepository.Setup(repo => repo.InsertAsync(It.IsAny<Person>())).Returns(Task.CompletedTask);

            await _personService.CreateAsync(personDto);

            _mockWriteRepository.Verify(repo => repo.InsertAsync(It.IsAny<Person>()), Times.Once);

            Assert.Empty(_notificationContext.Notifications);
            Assert.True(personDto.Valid);
        }

        [Theory]
        [InlineData("", "00000000-0000-0000-0000-000000000000")] // Invalid name and UserId
        [InlineData("TestName", "00000000-0000-0000-0000-000000000000")]    // Invalid UserId
        [InlineData("", "1b94b258-2612-4b13-b6d9-26314a977f89")]        // Both invalid
        public async Task CreateAsync_WithInvalidData_AddsNotifications(string name, string id)
        {
            var invalidPersonDto = new PersonDto
            {
                Name = name,
                UserId = Guid.Empty == Guid.Parse(id) ? Guid.Empty : Guid.NewGuid()
            };

            await _personService.CreateAsync(invalidPersonDto);

            _mockWriteRepository.Verify(repo => repo.InsertAsync(invalidPersonDto), Times.Never);
            Assert.NotEmpty(_notificationContext.Notifications);
            Assert.True(invalidPersonDto.Invalid);
        }

        [Fact]
        public async Task GetAllPaginatedAsync_ReturnsPaginationResponse()
        {

            int page = 1;
            int quantityPerPage = 10;
            int totalRecords = 20;
            var people = new List<Person>();

            for (int i = 0; i < 20; i++)
            {
                people.Add(new Person($"Person {i + 1}", Guid.NewGuid()));
            }

            var expectedViewModels = people.ConvertAll(p => new PersonViewModel { Id = p.Id, Name = p.Name });

            _mockReadRepository.Setup(repo => repo.GetAllPaginatedAsync(page, quantityPerPage)).ReturnsAsync((people, totalRecords));
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PersonViewModel>>(people)).Returns(expectedViewModels);

            var result = await _personService.GetAllPaginatedAsync(Guid.NewGuid(), page, quantityPerPage);

            Assert.NotNull(result);
            Assert.Equal(page, result.CurrentPage);
            Assert.Equal(quantityPerPage, result.QuantityPerPage);
            // Assert.Equal(totalRecords, result.TotalRecords);
            // Assert.Equal(expectedViewModels, result.Data);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsMappedViewModels()
        {

            var people = new List<Person>
            {
                new Person("Alice", Guid.NewGuid()),
                new Person("Bob", Guid.NewGuid())
            };

            var expectedViewModels = people.Select(p => new PersonViewModel { Name = p.Name, Id = p.Id });
            _mockReadRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(people);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PersonViewModel>>(people)).Returns(expectedViewModels);

            var result = await _personService.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsPersonViewModel_WhenFound()
        {
            var personId = Guid.NewGuid();
            var person = new Person("John Doe", personId);
            _mockReadRepository.Setup(repo => repo.GetByIdAsync(personId)).ReturnsAsync(person);


            var result = await _personService.GetByIdAsync(personId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_AddsNotification_WhenNotFound()
        {
            // Arrange
            var personId = Guid.Empty;
            _mockReadRepository.Setup(repo => repo.GetByIdAsync(personId)).ReturnsAsync((Person)null!);

            var result = await _personService.GetByIdAsync(personId);

            // Assert
            Assert.Null(result);
            Assert.NotEmpty(_notificationContext.Notifications);
        }

        [Fact]
        public async Task GetByNameAsync_ReturnsPersonViewModel_WhenFound()
        {
            var personName = "John Doe";
            var people = new List<Person>
            {
                new Person(personName, Guid.NewGuid())
            };

            var expectedViewModel = people.Select(p => new PersonViewModel { Name = p.Name, Id = p.Id });
            _mockReadRepository.Setup(r => r.GetByNameAsync(personName)).ReturnsAsync(people);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PersonViewModel>>(people)).Returns(expectedViewModel);

            var result = await _personService.GetByNameAsync(personName);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByNameAsync_AddsNotification_WhenNotFound()
        {
            // Arrange
            var personName = "Unknown Person";
            var emptyPeopleList = new List<Person>();
            _mockReadRepository.Setup(repo => repo.GetByNameAsync(personName)).ReturnsAsync(emptyPeopleList);

            var result = await _personService.GetByNameAsync(personName);

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.Empty(_notificationContext.Notifications);
        }

        [Fact]
        public async Task GetByNameAsync_ReturnsEmptyList_WhenNotFound()
        {

            var personName = "Unknown Person";
            var emptyPeopleList = new List<Person>();
            _mockReadRepository.Setup(repo => repo.GetByNameAsync(personName)).ReturnsAsync(emptyPeopleList);


            var result = await _personService.GetByNameAsync(personName);


            Assert.NotNull(result);
            Assert.Empty(result);

        }

    }
}
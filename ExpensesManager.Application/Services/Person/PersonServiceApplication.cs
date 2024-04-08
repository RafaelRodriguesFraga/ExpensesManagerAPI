using AutoMapper;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Application.Pagination;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Application.Services.Person
{
    public class PersonServiceApplication : BaseServiceApplication, IPersonServiceApplication
    {
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IPersonReadRepository _personReadRepository;
        private IMapper _mapper;

        public PersonServiceApplication(NotificationContext notificationContext, IPersonWriteRepository personWriteRepository, IPersonReadRepository personReadRepository, IMapper mapper) : base(notificationContext)
        {
            _personWriteRepository = personWriteRepository;
            _personReadRepository = personReadRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PersonDto person)
        {
            person.Validate();
            var personHasErrors = person.Invalid;
            if (personHasErrors)
            {
                _notificationContext.AddNotifications(person.Notifications);
                return;
            }

            await _personWriteRepository.InsertAsync(person);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllAsync()
        {
            var person = await _personReadRepository.GetAllAsync();
            var personViewModelList = _mapper.Map<IEnumerable<PersonViewModel>>(person);

            return personViewModelList;
        }

        public async Task<PaginationResponse<PersonViewModel>> GetAllPaginatedAsync(int page, int quantityPerPage)
        {
            var (people, totalRecords) = await _personReadRepository.GetAllPaginatedAsync(page, quantityPerPage);

            var personViewModelList = _mapper.Map<IEnumerable<PersonViewModel>>(people);

            return new PaginationResponse<PersonViewModel>(page, quantityPerPage, totalRecords, personViewModelList);
        }

        public async Task<PersonViewModel> GetByIdAsync(Guid id)
        {
            var person = await _personReadRepository.GetByIdAsync(id);
            if (person == null)
            {
                _notificationContext.AddNotification("Error", "Person not found");
                return default!;
            }

            return person;
        }

        public async Task<PersonViewModel> GetByNameAsync(string name)
        {
            var person = await _personReadRepository.GetByNameAsync(name);
            if (person == null)
            {
                _notificationContext.AddNotification("Error", "Person not found");
                return default!;
            }
            return person;
        }
    }
}
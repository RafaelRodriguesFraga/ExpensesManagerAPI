using AutoMapper;
using DotnetBaseKit.Components.Application.Base;
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

        public async Task AddPersonAsync(PersonDto person)
        {
            await _personWriteRepository.InsertAsync(person);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllAsync()
        {
            var person = await _personReadRepository.GetAllAsync();
            var personViewModel = _mapper.Map<IEnumerable<PersonViewModel>>(person);

            return personViewModel;
        }

        public async Task<PersonViewModel> GetPersonByIdAsync(Guid id)
        {
            var person = await _personReadRepository.GetByIdAsync(id);
            if (person == null)
            {
                _notificationContext.AddNotification("Error", "Person not found");
                return default!;
            }

            return person;
        }

        public async Task<PersonViewModel> GetPersonByNameAsync(string name)
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
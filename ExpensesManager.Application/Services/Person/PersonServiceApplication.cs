using AutoMapper;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Application.Pagination;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Shared.Localization;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Application.Services.Person
{
    public class PersonServiceApplication : BaseServiceApplication, IPersonServiceApplication
    {
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IPersonReadRepository _personReadRepository;
        private IMapper _mapper;
        private readonly IStringLocalizer _localizer;


        public PersonServiceApplication(
            NotificationContext notificationContext,
            IPersonWriteRepository personWriteRepository,
            IPersonReadRepository personReadRepository,
            IMapper mapper,
            IStringLocalizerFactory localizerFactory) : base(notificationContext)
        {
            _personWriteRepository = personWriteRepository;
            _personReadRepository = personReadRepository;
            _mapper = mapper;

            var assembly = typeof(Messages).Assembly;
            _localizer = localizerFactory.Create("Localization.Messages", assembly.GetName().Name);
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

        public async Task<PaginationResponse<PersonViewModel>> GetAllPaginatedAsync(Guid userId, int page, int quantityPerPage)
        {
            var (people, totalRecords) = await _personReadRepository.GetAllAsync(userId, page, quantityPerPage);

            var personViewModelList = _mapper.Map<IEnumerable<PersonViewModel>>(people);

            return new PaginationResponse<PersonViewModel>(page, quantityPerPage, totalRecords, personViewModelList);
        }

        public async Task<PersonViewModel> GetByIdAsync(Guid id)
        {
            var person = await _personReadRepository.GetByIdAsync(id);
            if (person == null)
            {
                _notificationContext.AddNotification(_localizer["Error"], _localizer["PersonNotFound"]);
                return default!;
            }

            return person;
        }

        public async Task<IEnumerable<PersonViewModel>> GetByNameAsync(string name)
        {
            var people = await _personReadRepository.GetByNameAsync(name);
            var personViewModelList = _mapper.Map<IEnumerable<PersonViewModel>>(people);
            
            return personViewModelList;
        }
    }
}
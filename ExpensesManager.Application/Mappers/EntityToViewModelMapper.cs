using AutoMapper;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.Mappers
{
    public class EntityToViewModelMapper : Profile
    {
        public EntityToViewModelMapper()
        {
            CreateMap<IEnumerable<Person>, IEnumerable<PersonViewModel>>();
        }
    }
}
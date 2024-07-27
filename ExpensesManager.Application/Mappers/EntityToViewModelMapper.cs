using AutoMapper;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.Mappers
{
    public class EntityToViewModelMapper : Profile
    {
        public EntityToViewModelMapper()
        {
            CreateMap<Person, PersonViewModel>();

            CreateMap<Expense, ExpenseViewModel>()
                .ForMember(dest => dest.InvoiceMonth, opt => opt.MapFrom(src => src.InvoiceMonth.Name));
            CreateMap<Expense, ExpenseGroupByPurchaseDateViewModel>()
               .ForMember(dest => dest.InvoiceMonth, opt => opt.MapFrom(src => src.InvoiceMonth.Name));
        }
    }
}
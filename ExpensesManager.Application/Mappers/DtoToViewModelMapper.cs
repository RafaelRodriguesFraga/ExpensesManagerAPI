using AutoMapper;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Application.ViewModels.Person;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.Mappers
{
    public class DtoToViewModelMapper : Profile
    {
        public DtoToViewModelMapper()
        {
            CreateMap<TotalExpenseDto, TotalExpenseViewModel>();
        }
    }
}
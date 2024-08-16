using AutoMapper;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Application.Mappers
{
    public class DtoToViewModelMapper : Profile
    {
        public DtoToViewModelMapper()
        {
            CreateMap<TotalExpenseDto, TotalExpenseViewModel>();
            CreateMap<MonthlyTotalExpenseReportDto, MonthlyTotalExpenseReportViewModel>();


        }
    }
}
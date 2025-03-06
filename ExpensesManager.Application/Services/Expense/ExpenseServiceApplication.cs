using System.Numerics;
using AutoMapper;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Shared.Localization;
using Microsoft.Extensions.Localization;

namespace ExpensesManager.Application.Services.Expense
{
    public class ExpenseServiceApplication : BaseServiceApplication, IExpenseServiceApplication
    {
        private readonly IExpenseWriteRepository _writeRepository;
        private readonly IExpenseReadRepository _readRepository;
        private readonly IMonthReadRepository _monthReadRepository;
        private readonly IStringLocalizer _localizer;

        private IMapper _mapper;
        public ExpenseServiceApplication(NotificationContext notificationContext,
            IExpenseWriteRepository writeRepository,
            IExpenseReadRepository readRepository,
            IMapper mapper,
            IMonthReadRepository monthReadRepository,
            IStringLocalizerFactory localizerFactory) : base(notificationContext)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
            _monthReadRepository = monthReadRepository;

            var assembly = typeof(Messages).Assembly;
            _localizer = localizerFactory.Create("Localization.Messages", assembly.GetName().Name);
        }

        public async Task CreateAsync(ExpenseDto expenseDto)
        {
            expenseDto.Validate();
            var expenseHasErrors = expenseDto.Invalid;
            if (expenseHasErrors)
            {
                _notificationContext.AddNotifications(expenseDto.Notifications);
                return;
            }

            if (expenseDto.IsInstallment)
            {
                int totalInstallments = expenseDto.TotalInstallments;
                decimal installmentPrice = expenseDto.Price / totalInstallments;
                installmentPrice = Math.Round(installmentPrice, 2);
                
                for (int i = 1; i <= totalInstallments; i++)
                {
                    var installmentDate = expenseDto.PurchaseDate.AddMonths(i);
                    var invoiceMonthId = await GetInvoiceMonthIdByDateAsync(installmentDate);

                    var expensesDto = new ExpenseDto
                    {
                        CreditCardName = expenseDto.CreditCardName,
                        Description = expenseDto.Description,
                        Price = expenseDto.Price,
                        PurchaseDate = expenseDto.PurchaseDate,
                        InvoiceMonthId = invoiceMonthId,
                        IsInstallment = expenseDto.IsInstallment,
                        TotalInstallments = totalInstallments,
                        InstallmentPrice = installmentPrice,
                        CurrentInstallment = i,
                        InstallmentInfo = $"Parcela {i} de {totalInstallments}",
                        PersonId = expenseDto.PersonId
                    };

                    await _writeRepository.InsertAsync(expensesDto);

                }
            }
            else
            {
                await _writeRepository.InsertAsync(expenseDto);
            }


        }

        public async Task<Dictionary<string, IEnumerable<ExpenseGroupByPurchaseDateViewModel>>> FindByCreditCardNameAndInvoiceMonthAsync(string credtCardName, string invoiceMonth, Guid personId)
        {
            var expenses = await _readRepository.FindByCreditCardNameAndInvoiceMonthAsync(credtCardName, invoiceMonth, personId);

            var expenseViewModelDict = new Dictionary<string, IEnumerable<ExpenseGroupByPurchaseDateViewModel>>();

            foreach (var keyValuePair in expenses)
            {
                var expenseViewModelList = _mapper.Map<IEnumerable<ExpenseGroupByPurchaseDateViewModel>>(keyValuePair.Value);
                expenseViewModelDict.Add(keyValuePair.Key, expenseViewModelList);
            }

            return expenseViewModelDict;
        }

        public async Task<IEnumerable<ExpenseViewModel>> GetAllAsync(Guid personId)
        {
            var expenses = await _readRepository.GetAllAsync(personId);
            var expenseViewModelList = _mapper.Map<IEnumerable<ExpenseViewModel>>(expenses);

            return expenseViewModelList;
        }

        public async Task<Dictionary<string, IEnumerable<ExpenseGroupByPurchaseDateViewModel>>> GetAllGroupByPurchaseDateAsync(Guid personId, string invoiceMonth)
        {
            var expenses = await _readRepository.GetAllGroupByPurchaseDateAsync(personId, invoiceMonth);

            var expenseViewModelDict = new Dictionary<string, IEnumerable<ExpenseGroupByPurchaseDateViewModel>>();

            foreach (var keyValuePair in expenses)
            {
                var expenseViewModelList = _mapper.Map<IEnumerable<ExpenseGroupByPurchaseDateViewModel>>(keyValuePair.Value);
                expenseViewModelDict.Add(keyValuePair.Key, expenseViewModelList);
            }

            return expenseViewModelDict;
        }

        public async Task<Dictionary<string, MonthlyTotalExpenseReportViewModel>> GetMonthlyTotalsReportAsync(Guid personId)
        {
            var monthlyTotals = await _readRepository.GetMonthlyTotalsReportAsync(personId);

            var monthlyTotalsViewModelDict = new Dictionary<string, MonthlyTotalExpenseReportViewModel>();

            foreach (var keyValuePair in monthlyTotals)
            {
                var monthlyTotalsList = _mapper.Map<MonthlyTotalExpenseReportViewModel>(keyValuePair.Value);
                monthlyTotalsViewModelDict.Add(keyValuePair.Key, monthlyTotalsList);
            }

            return monthlyTotalsViewModelDict;
        }       

        public async Task<IEnumerable<TotalExpenseViewModel>> GetTotalByMonthAsync(Guid personId)
        {
            var expenses = await _readRepository.CalculateTotalAsync(personId);

            var totalExpensesMapped = _mapper.Map<IEnumerable<TotalExpenseViewModel>>(expenses);

            return totalExpensesMapped;
        }

         public async Task<IEnumerable<TotalExpenseViewModel>> GetTotalByMonthAndCreditCardNameAsync(string creditCardName, Guid personId)
        {
             var expenses = await _readRepository.CalculateTotalByCreditCardNameAsync(creditCardName, personId);

            var totalExpensesMapped = _mapper.Map<IEnumerable<TotalExpenseViewModel>>(expenses);

            return totalExpensesMapped;
        }

        private async Task<Guid> GetInvoiceMonthIdByDateAsync(DateTime installmentDate)
        {
            string monthCode = installmentDate.Month.ToString("D2"); // Formatacao para 01, 02, por exemplo
            var month = await _monthReadRepository.GetByCodeAsync(Convert.ToInt32(monthCode));

            var invalidMonth = month == null;
            if (invalidMonth)
            {
                _notificationContext.AddNotification(_localizer["Month"], _localizer["MonthNotFound"]);
                return default;
            }

            return month!.Id;
        }

    }
}
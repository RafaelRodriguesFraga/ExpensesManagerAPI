using AutoMapper;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Application.ViewModels.Expense;
using ExpensesManager.Domain.DTOs;
using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Application.Services.Expense
{
    public class ExpenseServiceApplication : BaseServiceApplication, IExpenseServiceApplication
    {
        private readonly IExpenseWriteRepository _writeRepository;
        private readonly IExpenseReadRepository _readRepository;
        private IMapper _mapper;
        public ExpenseServiceApplication(NotificationContext notificationContext,
            IExpenseWriteRepository writeRepository, 
            IExpenseReadRepository readRepository,
            IMapper mapper) : base(notificationContext)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
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

            await _writeRepository.InsertAsync(expenseDto);

        }

        public async Task<IEnumerable<ExpenseViewModel>> GetAllAsync(Guid personId)
        {
            var expenses = await _readRepository.GetAllAsync(personId);
            var expenseViewModelList = _mapper.Map<IEnumerable<ExpenseViewModel>>(expenses);

            return expenseViewModelList;
        }
        
        public async Task<Dictionary<string, IEnumerable<ExpenseViewModel>>> GetAllGroupByPurchaseDateAsync(Guid personId, Guid invoiceMonthId)
        {
            var expenses = await _readRepository.GetAllGroupByPurchaseDateAsync(personId, invoiceMonthId);

            var expenseViewModelDict = new Dictionary<string, IEnumerable<ExpenseViewModel>>();

            foreach (var keyValuePair in expenses)
            {
                var expenseViewModelList = _mapper.Map<IEnumerable<ExpenseViewModel>>(keyValuePair.Value);
                expenseViewModelDict.Add(keyValuePair.Key, expenseViewModelList);
            }          

            return expenseViewModelDict;
        }
    }
}
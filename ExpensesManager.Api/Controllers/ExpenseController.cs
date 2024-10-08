using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services.Expense;
using ExpensesManager.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers
{
    [Route("api/expenses")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ExpensesController : ApiControllerBase
    {
        private readonly IExpenseServiceApplication _expensesServiceApplication;

        public ExpensesController(IResponseFactory responseFactory, IExpenseServiceApplication expensesServiceApplication) : base(responseFactory)
        {
            _expensesServiceApplication = expensesServiceApplication;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ExpenseDto expensesDto)
        {
            await _expensesServiceApplication.CreateAsync(expensesDto);

            return ResponseCreated();
        }

        [HttpGet("{personId:guid}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] Guid personId)
        {

            var expenses = await _expensesServiceApplication.GetAllAsync(personId);

            return ResponseOk(expenses);
        }

        [HttpGet("personId/{personId:guid}")]
        public async Task<IActionResult> GetAllGroupByPurchaseDateAsync([FromRoute] Guid personId, [FromQuery] string invoiceMonth)
        {

            var expenses = await _expensesServiceApplication.GetAllGroupByPurchaseDateAsync(personId, invoiceMonth);

            return ResponseOk(expenses);
        }

        [HttpGet("totalByMonth")]
        public async Task<IActionResult> GetTotalByMonthAsync([FromQuery] Guid personId)
        {

            var expenses = await _expensesServiceApplication.GetTotalByMonthAsync(personId);

            return ResponseOk(expenses);
        }

        [HttpGet("personId/{personId:guid}/creditCardName/{creditCardName}")]
        public async Task<IActionResult> FindByCreditCardNameAndInvoiceMonthAsync([FromRoute] Guid personId, [FromRoute] string creditCardName, [FromQuery] string invoiceMonth)
        {
            var expenses = await _expensesServiceApplication.FindByCreditCardNameAndInvoiceMonthAsync(creditCardName, invoiceMonth, personId);
            return ResponseOk(expenses);
        }

        [HttpGet("personId/{personId:guid}/monthly-totals-report")]
        public async Task<IActionResult> GetMonthlyTotalsReportAsync([FromRoute] Guid personId) {

            var monthlyTotals = await _expensesServiceApplication.GetMonthlyTotalsReportAsync(personId);
            return ResponseOk(monthlyTotals);
        }

    }
}
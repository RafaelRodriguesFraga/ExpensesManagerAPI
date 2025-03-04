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

        /// <summary>
        /// Creates a new expense
        /// </summary>
        /// <param name="expensesDto"></param>
        /// <returns>A response indicating the expense was created</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /expenses
        ///     {
        ///        "creditCardName": "Visa",
        ///        "description": "Grocery Shopping",
        ///        "price": 100.50,
        ///        "purchaseDate": "2025-03-04T04:47:03.020Z",
        ///        "invoiceMonthId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "isInstallment": true,
        ///        "totalInstallments": 6,
        ///        "personId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns a response indicating that the expense was created successfully</response>
        /// <response code="400">If the expense data is invalid or missing required fields</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ExpenseDto expensesDto)
        {
            await _expensesServiceApplication.CreateAsync(expensesDto);

            return ResponseCreated();
        }

        /// <summary>
        /// Retrieves all expenses of a person
        /// </summary>
        /// <param name="personId">The person's id</param>
        /// <returns>A list of expenses for the specified person</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /expenses/3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///
        /// </remarks>
        /// <response code="200">Returns the list of expenses for the specified person</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpGet("{personId:guid}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] Guid personId)
        {

            var expenses = await _expensesServiceApplication.GetAllAsync(personId);

            return ResponseOk(expenses);
        }

        /// <summary>
        /// Retrieves all expenses grouped by purchase date of a person and invoice month
        /// </summary>
        /// <param name="personId">The person's id</param>
        /// <param name="invoiceMonth">The invoice month</param>
        /// <returns>A list of expenses grouped by purchase date</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /expenses/personId/3fa85f64-5717-4562-b3fc-2c963f66afa6?invoiceMonth=Janeiro
        ///
        /// </remarks>
        /// <response code="200">Returns the list of expenses grouped by purchase date for the specified person and month</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpGet("personId/{personId:guid}")]
        public async Task<IActionResult> GetAllGroupByPurchaseDateAsync([FromRoute] Guid personId, [FromQuery] string invoiceMonth)
        {

            var expenses = await _expensesServiceApplication.GetAllGroupByPurchaseDateAsync(personId, invoiceMonth);

            return ResponseOk(expenses);
        }

        /// <summary>
        /// Retrieves the total expenses of a person by month
        /// </summary>
        /// <param name="personId">The person's id</param>
        /// <returns>The total expenses for the specified person by month</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /expenses/totalByMonth?personId=3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///
        /// </remarks>
        /// <response code="200">Returns the total expenses for the specified person by month</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpGet("totalByMonth")]
        public async Task<IActionResult> GetTotalByMonthAsync([FromQuery] Guid personId)
        {

            var expenses = await _expensesServiceApplication.GetTotalByMonthAsync(personId);

            return ResponseOk(expenses);
        }

        /// <summary>
        /// Retrieves expenses filtered by credit card name and invoice month for a given person
        /// </summary>
        /// <param name="personId">The person's id</param>
        /// <param name="creditCardName">The credit card name</param>
        /// <param name="invoiceMonth">The invoice month</param>
        /// <returns>A list of expenses filtered by credit card name and invoice month</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /expenses/personId/3fa85f64-5717-4562-b3fc-2c963f66afa6/creditCardName/Inter?invoiceMonth=Janeiro
        ///     
        /// </remarks>
        /// <response code="200">Returns the filtered list of expenses</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>

        [HttpGet("personId/{personId:guid}/creditCardName/{creditCardName}")]
        public async Task<IActionResult> FindByCreditCardNameAndInvoiceMonthAsync([FromRoute] Guid personId, [FromRoute] string creditCardName, [FromQuery] string invoiceMonth)
        {
            var expenses = await _expensesServiceApplication.FindByCreditCardNameAndInvoiceMonthAsync(creditCardName, invoiceMonth, personId);
            return ResponseOk(expenses);
        }

        /// <summary>
        /// Retrieves a monthly totals report of expenses for a given person
        /// </summary>
        /// <param name="personId">The person's id</param>
        /// <returns>A monthly totals report of expenses for the specified person</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /expenses/personId/3fa85f64-5717-4562-b3fc-2c963f66afa6/monthly-totals-report
        ///
        /// </remarks>
        /// <response code="200">Returns the monthly totals report for the specified person</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpGet("personId/{personId:guid}/monthly-totals-report")]
        public async Task<IActionResult> GetMonthlyTotalsReportAsync([FromRoute] Guid personId)
        {

            var monthlyTotals = await _expensesServiceApplication.GetMonthlyTotalsReportAsync(personId);
            return ResponseOk(monthlyTotals);
        }

    }
}
using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services.Expense;
using ExpensesManager.Application.Services.Person;
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
    }
}
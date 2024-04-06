using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services.Person;
using ExpensesManager.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PersonController : ApiControllerBase
    {
        private IPersonServiceApplication _personServiceApplication;

        public PersonController(IResponseFactory responseFactory, IPersonServiceApplication personServiceApplication) : base(responseFactory)
        {
            _personServiceApplication = personServiceApplication;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonDto personDto)
        {
            await _personServiceApplication.AddPersonAsync(personDto);

            return ResponseCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var people = await _personServiceApplication.GetAllAsync();

            return ResponseOk(people);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByNameAsync([FromRoute] string name)
        {
            var person = await _personServiceApplication.GetPersonByNameAsync(name);

            return ResponseOk(person);
        }
    }
}
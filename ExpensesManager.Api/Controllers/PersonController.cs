using System.Security.Claims;
using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services.Person;
using ExpensesManager.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers
{
    [Route("api/person")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PersonController : ApiControllerBase
    {
        private IPersonServiceApplication _personServiceApplication;

        public PersonController(IResponseFactory responseFactory, IPersonServiceApplication personServiceApplication) : base(responseFactory)
        {
            _personServiceApplication = personServiceApplication;
        }

        /// <summary>
        /// Creates a new person
        /// </summary>
        /// <param name="personDto">The person data to be created</param>
        /// <returns>A response indicating the person was created</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /person
        ///     {
        ///        "name": "John Doe",
        ///        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns a response indicating that the person was created successfully</response>
        /// <example>
        /// {success: true, errors: []}
        /// </example>
        /// <response code="400">If the person data is invalid or missing required fields</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        /// <response code="500">If something else is wrong</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PersonDto personDto)
        {
            await _personServiceApplication.CreateAsync(personDto);

            return ResponseCreated();
        }

        /// <summary>
        /// Gets all people associated with a specific user, paginated.
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="page">The page number</param>
        /// <param name="quantityPerPage">The number of records per page</param>
        /// <returns>A list of people associated with the specified user.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /person/userId/3fa85f64-5717-4562-b3fc-2c963f66afa6?page=1&amp;quantityPerPage=10
        ///
        /// </remarks>
        /// <response code="200">Returns the paginated list of people</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="403">If the userId in the request does not match the logged-in user</response>
        [HttpGet("userId/{userId:guid}")]
        public async Task<IActionResult> GetAllAsync(Guid userId, [FromQuery] int page, [FromQuery] int quantityPerPage)
        {
            var loggedUser = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            if (loggedUser != userId)
            {
                return Forbid();
            }
            var people = await _personServiceApplication.GetAllPaginatedAsync(userId, page, quantityPerPage);

            return ResponseOk(people);
        }

        /// <summary>
        /// Gets a person by name
        /// </summary>
        /// <param name="name">The person's name</param>
        /// <returns>The person data that matches the provided name</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /person?name=John Doe
        ///
        /// </remarks>
        /// <response code="200">Returns the person data matching the name.</response>
        /// <response code="401">If the user is not authenticated</response>
        [HttpGet]
        public async Task<IActionResult> GetByNameAsync([FromQuery] string name)
        {
            var person = await _personServiceApplication.GetByNameAsync(name);

            return ResponseOk(person);
        }
    }
}
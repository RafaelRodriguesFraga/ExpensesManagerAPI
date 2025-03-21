using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.User;
using ExpensesManager.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
namespace TestApi.Api.Controllers

{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserServiceApplication _userServiceApplication;

        public UserController(IResponseFactory responseFactory, IUserServiceApplication userServiceApplication) : base(responseFactory)
        {
            _userServiceApplication = userServiceApplication;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userRequestDto">The user data to be created</param>
        /// <returns>A response indicating the user was created successfully</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user
        ///     {
        ///        "email": "test@test.com",
        ///        "password": "123456",
        ///        "confirmPassword": "123456"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns a response indicating the user was created successfully</response>
        /// <response code="400">If the user data is invalid or missing required fields</response>        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(UserRequestDto userRequestDto)
        {
            await _userServiceApplication.CreateAsync(userRequestDto);

            return ResponseCreated();
        }
    }
}
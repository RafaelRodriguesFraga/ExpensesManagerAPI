using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Interfaces;
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
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(UserRequestDto userRequestDto)
        {
            await _userServiceApplication.CreateAsync(userRequestDto);

            return ResponseCreated();
        }
    }
}
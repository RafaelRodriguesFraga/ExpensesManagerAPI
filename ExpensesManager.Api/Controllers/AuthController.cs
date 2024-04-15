using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.User;
using ExpensesManager.Application.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Api.Controllers

{
    [Route("api/[controller]")]
    public class AuthController : ApiControllerBase
    {
        private readonly ITokenServiceApplication _tokenServiceApplication;
         private readonly IUserServiceApplication _userServiceApplication;

        public AuthController(IResponseFactory responseFactory, ITokenServiceApplication tokenServiceApplication, IUserServiceApplication userServiceApplication) : base(responseFactory)
        {
            _tokenServiceApplication = tokenServiceApplication;
            _userServiceApplication = userServiceApplication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestViewModel loginRequestViewModel)
        {

            var authenticateUser = await _userServiceApplication.AuthenticateAsync(loginRequestViewModel);      
            
            var invalidUser = authenticateUser == null;
            if (invalidUser)
            {
                return ResponseBadRequest(authenticateUser);
            }
            
            var token = _tokenServiceApplication.GenerateTokenAsync(authenticateUser);

            return ResponseOk(token);
        }
    }
}
using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Auth;
using ExpensesManager.Application.Services.User;
using ExpensesManager.Application.ViewModels.Auth;
using ExpensesManager.Application.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiControllerBase
    {
        private readonly ITokenServiceApplication _tokenServiceApplication;
        private readonly IUserServiceApplication _userServiceApplication;
        private readonly IAuthServiceApplication _authServiceApplication;

        public AuthController(IResponseFactory responseFactory, ITokenServiceApplication tokenServiceApplication,
            IUserServiceApplication userServiceApplication, IAuthServiceApplication authServiceApplication) : base(responseFactory)
        {
            _tokenServiceApplication = tokenServiceApplication;
            _userServiceApplication = userServiceApplication;
            _authServiceApplication = authServiceApplication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestViewModel loginViewModel)
        {
            var authenticateUser = await _userServiceApplication.AuthenticateAsync(loginViewModel);
            var userIsNull = authenticateUser == null;
            if (userIsNull)
            {
                return ResponseBadRequest(authenticateUser);
            }

            var token = _tokenServiceApplication.GenerateTokenAsync(authenticateUser);

            return ResponseOk(token);
        }

        [HttpPost("reset-password")]         
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel)
        {
            await _authServiceApplication.ResetPasswordAsync(resetPasswordViewModel.Email, resetPasswordViewModel.NewPassword);

            return CreateResponse();
        }
    }
}
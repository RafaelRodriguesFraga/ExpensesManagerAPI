using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Auth;
using ExpensesManager.Application.Services.User;
using ExpensesManager.Application.ViewModels.Auth;
using ExpensesManager.Application.ViewModels.Login;
using ExpensesManager.Application.ViewModels.Token;
using ExpensesManager.Shared.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpensesManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiControllerBase
    {
        private readonly ITokenServiceApplication _tokenServiceApplication;
        private readonly IUserServiceApplication _userServiceApplication;
        private readonly IAuthServiceApplication _authServiceApplication;
        private readonly IStringLocalizer _localizer;


        public AuthController(IResponseFactory responseFactory,
            ITokenServiceApplication tokenServiceApplication,
            IUserServiceApplication userServiceApplication,
            IAuthServiceApplication authServiceApplication,
             IStringLocalizerFactory localizerFactory) : base(responseFactory)
        {
            _tokenServiceApplication = tokenServiceApplication;
            _userServiceApplication = userServiceApplication;
            _authServiceApplication = authServiceApplication;

            var assembly = typeof(Messages).Assembly;
            _localizer = localizerFactory.Create("Localization.Messages", assembly.GetName().Name);
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns>A object with authentication details</returns>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST /auth/login
        ///     {
        ///        "email": "test@test.com,
        ///        "password": "123456"        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the authentication token</response>
        /// <response code="400">If the login credentials are invalid</response>        
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

        /// <summary>
        /// Refreshes the authentication token
        /// </summary>
        /// <param name="refreshTokenViewModel"></param>
        /// <returns>A object with a new authentication token and refresh token</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/refresh-token
        ///     {
        ///        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
        ///        "refreshToken": "d7a472d5b929...bcd49f92"        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the new authentication token and refresh token</response>
        /// <response code="400">If the refresh token is invalid or expired</response>
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken(RefreshTokenRequestViewModel refreshTokenViewModel)

        {
            var principal = _tokenServiceApplication.GetPrincipalFromExpiredToken(refreshTokenViewModel.Token);
            var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email || c.Type == JwtRegisteredClaimNames.Email);
            var username = emailClaim?.Value;

            var savedRefreshToken = _tokenServiceApplication.GetRefreshToken(username);
            if (savedRefreshToken != refreshTokenViewModel.RefreshToken)
            {
                throw new SecurityTokenException(_localizer["InvalidRefreshToken"]);
            }

            var newToken = _tokenServiceApplication.GenerateToken(principal.Claims);
            var newRefreshToken = _tokenServiceApplication.GenerateRefreshToken();

            _tokenServiceApplication.DeleteRefreshToken(username, refreshTokenViewModel.RefreshToken);
            _tokenServiceApplication.SaveRefreshToken(username, newRefreshToken);

            var newRefreshTokenViewModel = new RefreshTokenResponseViewModel
            {
                NewToken = newToken,
                NewRefreshToken = newRefreshToken
            };

            return ResponseOk(newRefreshTokenViewModel);
        }
        /// <summary>
        /// Resets user's password
        /// </summary>
        /// <param name="resetPasswordViewModel"></param>
        /// <returns>A response indicating the password reset status.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/reset-password
        ///     {
        ///        "email": "test@test.com",
        ///        "newPassword": "newpassword123"        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Indicates the password has been reset successfully</response>
        /// <response code="400">If the email is not registered or the password does not meet security requirements</response>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel)
        {
            await _authServiceApplication.ResetPasswordAsync(resetPasswordViewModel.Email, resetPasswordViewModel.NewPassword);

            return CreateResponse();
        }
    }
}
using DotnetBoilerplate.Components.Api.Base;
using DotnetBoilerplate.Components.Api.Responses;
using ExpensesManager.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
namespace TestApi.Api.Controllers

{
    [Route("api/[controller]")]
    public class AuthController : ApiControllerBase
    {
        private readonly ITokenServiceApplication _tokenServiceApplication;

        public AuthController(IResponseFactory responseFactory, ITokenServiceApplication tokenServiceApplication) : base(responseFactory)
        {
            _tokenServiceApplication = tokenServiceApplication;
        }

        [HttpPost("test-login")]
        public IActionResult Login()
        {

            var id = Guid.NewGuid();
            var email = "test@test.com";

            var token = _tokenServiceApplication.GenerateTokenAsync(id, email);

            return ResponseCreated(token);
        }
    }
}
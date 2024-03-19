using DotnetBoilerplate.Components.Api.Base;
using DotnetBoilerplate.Components.Api.Responses;
using Microsoft.AspNetCore.Mvc;
namespace TestApi.Api.Controllers

{
    [Route("api/[controller]")]
    public class TestApiController : ApiControllerBase
    {
        public TestApiController(IResponseFactory responseFactory) : base(responseFactory)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ResponseOk("Hello World");
        }
    }
}
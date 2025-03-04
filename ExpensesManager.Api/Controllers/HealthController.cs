using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers;

[Route("api/health")]

public class HealthController : ControllerBase
{
    /// <summary>
        /// Checks the health status of the api
        /// </summary>
        /// <returns>A simple response indicating the API is up and running.</returns>       
        /// <response code="200">Returns a response indicating the API is healthy</response>
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(new { status = "pong" });
    }
}
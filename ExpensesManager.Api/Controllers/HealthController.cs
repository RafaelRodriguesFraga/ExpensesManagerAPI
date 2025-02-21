using DotnetBaseKit.Components.Api.Base;
using DotnetBaseKit.Components.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Api.Controllers;

[Route("api/health")]

public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(new { status = "pong" });
    }
}
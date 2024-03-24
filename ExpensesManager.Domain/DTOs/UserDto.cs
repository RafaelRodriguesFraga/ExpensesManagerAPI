using DotnetBoilerplate.Components.Domain.Dtos.Base;

namespace ExpensesManager.Domain.DTOs;

public class UserDto : BaseDto
{
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string ConfirmPassword { get; protected set; }

    public override void Validate()
    {
    }
}
using DotnetBoilerplate.Components.Domain.Dtos.Base;

namespace ExpensesManager.Domain.DTOs;

public class UserRequestDto : BaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public override void Validate()
    {
    }
}
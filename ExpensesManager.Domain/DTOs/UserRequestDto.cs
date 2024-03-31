using DotnetBoilerplate.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Validations;

namespace ExpensesManager.Domain.DTOs;

public class UserRequestDto : BaseDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public override void Validate()
    {
        var validator = new UserRequestContract();
        validator.Validate(this);
    }
}
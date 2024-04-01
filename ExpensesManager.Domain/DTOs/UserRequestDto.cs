using DotnetBaseKit.Components.Domain.Dtos.Base;
using ExpensesManager.Domain.Validations;

namespace ExpensesManager.Domain.DTOs;

public class UserRequestDto : BaseDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public override void Validate()
    {
        var validation = new UserRequestContract();
        var validationResult = validation.Validate(this);

        AddNotifications(validationResult);
    }
}
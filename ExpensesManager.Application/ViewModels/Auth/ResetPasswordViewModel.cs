namespace ExpensesManager.Application.ViewModels.Auth
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
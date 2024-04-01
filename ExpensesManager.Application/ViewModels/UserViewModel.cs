using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel(user.Email);
        }
    }
}
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
        public Guid Id {get; set;}
        public string Email { get; set; }

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel(user.Id, user.Email);
        }
    }
}
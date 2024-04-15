
namespace ExpensesManager.Application.ViewModels.User
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

        public static implicit operator UserViewModel(Domain.Entities.User user)
        {
            return new UserViewModel(user.Id, user.Email);
        }
    }
}
using DotnetBoilerplate.Components.Domain.Sql.Entities.Base;

namespace ExpensesManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; protected set; }
        public string Password { get; protected set; }

        private void HashPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public override void Validate()
        {
            
        }
    }
}
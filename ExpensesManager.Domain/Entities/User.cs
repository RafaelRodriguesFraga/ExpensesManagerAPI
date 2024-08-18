using DotnetBaseKit.Components.Domain.Sql.Entities.Base;
using ExpensesManager.Domain.DTOs;

namespace ExpensesManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            HashPassword(Password);
        }

        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public ICollection<Person> People { get; private set; }

        public static implicit operator User(UserRequestDto userRequestDto)
        {
            return new User(userRequestDto.Email, userRequestDto.Password);
        }

        private string HashPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);

            return Password;
        }
        
        public void SetPassword(string password) {
            Password = HashPassword(password);
        }

        public override void Validate()
        {
            
        }
    }
}
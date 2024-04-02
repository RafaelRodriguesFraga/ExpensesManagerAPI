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

        public static implicit operator User(UserRequestDto userRequestDto)
        {
            return new User(userRequestDto.Email, userRequestDto.Password);
        }

        private void HashPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public override void Validate()
        {
            
        }
    }
}
using DotnetBoilerplate.Components.Domain.Sql.Entities.Base;
using ExpensesManager.Domain.ValueObjects;

namespace ExpensesManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; protected set; }
        public PasswordValueObject Password { get; protected set; }

        public override void Validate()
        {
            
        }
    }
}
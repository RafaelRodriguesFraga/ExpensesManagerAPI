using DotnetBoilerplate.Components.Domain.Sql.Entities.Base;

namespace ExpensesManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public override void Validate()
        {
            
        }
    }
}
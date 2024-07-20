using DotnetBaseKit.Components.Domain.Sql.Entities.Base;

namespace ExpensesManager.Domain.Entities;

public class CreditCard : BaseEntity
{
    public CreditCard(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    
    public override void Validate()
    {
        
    }
}
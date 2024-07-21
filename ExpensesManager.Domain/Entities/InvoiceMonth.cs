using DotnetBaseKit.Components.Domain.Sql.Entities.Base;

namespace ExpensesManager.Domain.Entities;

public class InvoiceMonth : BaseEntity
{
    public InvoiceMonth(string name, int code)
    {
        Name = name;
        Code = code;
    }

    public string Name { get; private set; }
    public int Code { get; private set; }
    public ICollection<Expense> Expenses { get; private set; }


    public override void Validate()
    {
        
    }
}
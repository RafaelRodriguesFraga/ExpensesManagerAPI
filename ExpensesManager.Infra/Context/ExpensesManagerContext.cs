using DotnetBaseKit.Components.Infra.Sql.Context.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using ExpensesManager.Infra.Configurations;
using ExpensesManager.Infra.Sql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infra.Context
{
    public class ExpensesManagerContext : BaseContext
    {
        public ExpensesManagerContext(DbContextOptions<ExpensesManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());

        }
    }
}
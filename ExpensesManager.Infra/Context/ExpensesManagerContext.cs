using DotnetBoilerplate.Components.Infra.Sql.Context.Base;
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

            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
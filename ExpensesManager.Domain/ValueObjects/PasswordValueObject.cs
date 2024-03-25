using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Domain.ValueObjects
{
    public class PasswordValueObject
    {
        protected PasswordValueObject() { }
        public PasswordValueObject(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public string Password { get; private set; }
    }
}

using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerEmail
    {
        public string Value { get; }

        public CustomerEmail(string value)
        {
            //TODO check email format
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerEmailException();
            }
            Value = value;
        }
        public static implicit operator string(CustomerEmail email)
       => email.Value;

        public static implicit operator CustomerEmail(string email)
            => new(email);
    }
}

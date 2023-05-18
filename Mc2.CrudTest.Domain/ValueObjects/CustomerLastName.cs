using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerLastName
    {
        public string Value { get;}
        public CustomerLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerLastNameException();
            }

            Value = value.Trim();
        }
        public static implicit operator string(CustomerLastName name)
           => name.Value;

        public static implicit operator CustomerLastName(string name)
            => new(name);
    }
}

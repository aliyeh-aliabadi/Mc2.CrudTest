using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerFirstName
    {
        public string Value { get; }

        public CustomerFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerNameException();
            }

            Value = value.Trim();
        }


        public static implicit operator string(CustomerFirstName name)
            => name.Value;

        public static implicit operator CustomerFirstName(string name)
            => new(name);
    }
}

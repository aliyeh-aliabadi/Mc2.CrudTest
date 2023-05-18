using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record class CustomerId
    {
        public Guid Value { get; }

        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new CustomerIdException();
            }
            Value = value;
        }
        public static implicit operator Guid(CustomerId id)
  => id.Value;

        public static implicit operator CustomerId(Guid id)
            => new(id);
    }
}

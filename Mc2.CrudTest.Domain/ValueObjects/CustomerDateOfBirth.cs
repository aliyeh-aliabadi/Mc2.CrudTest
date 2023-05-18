using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerDateOfBirth
    {
        public DateTime Value { get; }

        public CustomerDateOfBirth(DateTime value)
        {
            //TODO we can add some code to check if customer age is bigger than 18
            Value = value;
        }


        public static implicit operator DateTime(CustomerDateOfBirth dateOfBirth)
            => dateOfBirth.Value;

        public static implicit operator CustomerDateOfBirth(DateTime dateOfBirth)
            => new(dateOfBirth);
    }
}

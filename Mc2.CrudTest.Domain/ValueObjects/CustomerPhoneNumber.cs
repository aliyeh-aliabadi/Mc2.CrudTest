using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerPhoneNumber
    {
        public string Value { get; }

        public CustomerPhoneNumber(string value)
        {
            //TODO check phoneNumber format
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerPhoneNumberNullException();
            }

            Value = value.Trim();
        }

        public static implicit operator string(CustomerPhoneNumber phoneNumber)
          => phoneNumber.Value;

        public static implicit operator CustomerPhoneNumber(string phoneNumber)
            => new(phoneNumber);
    }
}

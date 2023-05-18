using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerBankAccountNumber
    {
        public string Value { get; }

        public CustomerBankAccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerBanckAccountNumberException();
            }

            Value = value.Trim();
        }


        public static implicit operator string(CustomerBankAccountNumber accountNumber)
            => accountNumber.Value;

        public static implicit operator CustomerBankAccountNumber(string accountNumber)
            => new(accountNumber);
    }
}

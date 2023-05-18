using Mc2.CrudTest.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class CustomerBanckAccountNumberException : CustomerException
    {
        public CustomerBanckAccountNumberException() : base("Customer BankAccountNumber cannot be empty.")
        { }
    }
}

using Mc2.CrudTest.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class CustomerNameException : CustomerException
    {
        public CustomerNameException() : base("Customer Name cannot be empty.")
        { }
    }
}

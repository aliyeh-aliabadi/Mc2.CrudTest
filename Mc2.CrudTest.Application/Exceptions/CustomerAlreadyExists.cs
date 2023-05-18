using Mc2.CrudTest.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class CustomerAlreadyExists : CustomerException
    {
        public string Name { get; }

        public CustomerAlreadyExists(string name) : base($"Customer with Email {name} is already exists.")
            => Name = name;
    }
}

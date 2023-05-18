using Mc2.CrudTest.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class CustomerNotFound : CustomerException
    {
        public Guid Id { get; }

        public CustomerNotFound(Guid id) : base($"Customer with ID '{id}' was not found.")
            => Id = id;
    }
}

using Mc2.CrudTest.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class EmailIsAlreadyExists : CustomerException
    {
        public string Email { get; }

        public EmailIsAlreadyExists(string email) : base($"Customer with Email '{email}' is already exists.")
            => Email = email;
    }
}

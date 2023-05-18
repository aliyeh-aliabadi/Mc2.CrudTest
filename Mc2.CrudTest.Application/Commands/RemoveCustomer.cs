using Mc2.CrudTest.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands
{
    public record RemoveCustomer(Guid Id) : ICommand;
}

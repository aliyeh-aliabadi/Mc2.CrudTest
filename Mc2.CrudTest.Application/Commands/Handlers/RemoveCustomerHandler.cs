using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    internal sealed class RemoveCustomerHandler : ICommandHandler<RemoveCustomer>
    {
        private readonly ICustomerRepository _repository;

        public RemoveCustomerHandler(ICustomerRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemoveCustomer command)
        {
            var Customer = await _repository.GetAsync(command.Id);

            if (Customer is null)
            {
                throw new CustomerNotFound(command.Id);
            }

            await _repository.DeleteAsync(Customer);
        }
    }
}

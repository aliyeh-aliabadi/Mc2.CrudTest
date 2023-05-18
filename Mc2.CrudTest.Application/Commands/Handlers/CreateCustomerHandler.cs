using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerFactory _factory;

        public CreateCustomerHandler(ICustomerRepository repository, ICustomerFactory factory)
        {
                _repository = repository;
            _factory = factory;
        }
        public async Task HandleAsync(CreateCustomer command)
        {
            //TODO check if customer is unique
            //TODO check if email is exsist
           
            var Customer = _factory.Create(command.Id,command.Name,command.LastName,command.DateOfBirth,command.PhoneNumber,command.Email,command.BankAccountNumber);

            await _repository.AddAsync(Customer);
        }
    }
}

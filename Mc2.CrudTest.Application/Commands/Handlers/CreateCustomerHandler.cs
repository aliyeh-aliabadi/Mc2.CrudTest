using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
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
        private readonly ICustomerReadService _readService;

        public CreateCustomerHandler(ICustomerRepository repository, ICustomerFactory factory,
            ICustomerReadService readService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
        }
        public async Task HandleAsync(CreateCustomer command)
        { 
            if (await _readService.ExistsByEmailAsync(command.Email))
            {
                throw new EmailAlreadyExists(command.Email);
            }
            if (await _readService.ExistsByNAmeLastNameDateOfBirthAsync(command.Name,command.LastName,command.DateOfBirth))
            {
                throw new CustomerAlreadyExists(string.Concat(command.Name,command.LastName));
            }

            var Customer = _factory.Create(command.Id, command.Name, command.LastName, command.DateOfBirth, command.PhoneNumber, command.Email, command.BankAccountNumber);

            await _repository.AddAsync(Customer);
        }
    }
}

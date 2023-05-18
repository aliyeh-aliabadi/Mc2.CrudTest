using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstractions.Commands;
using NSubstitute;
using Shouldly;
using System.Reflection;

namespace Mc2.TestCrud.UnitTest.Domain
{
    public class CreateCustomerHandlerTest
    {
        Task Act(CreateCustomer command)
      => _commandHandler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_Throws_CustomerAlreadyExistsException_When_Customer_With_same_Email_Already_Exists()
        {
            var command = new CreateCustomer(Guid.NewGuid(), "Aliyeh", "Aliabadi", Convert.ToDateTime("1987/10/21"), "+989151280270", "aliehaliabadi@gmail.com", "123456");

            _readService.ExistsByEmailAsync(command.Email).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmailAlreadyExists>();
        }

        [Fact]
        public async Task AddCustomer_Throws_CustomerAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name_LastName_And_DateOfBirth()
        {
            var command = new CreateCustomer(Guid.NewGuid(), "Aliyeh", "Aliabadi", Convert.ToDateTime("1987/10/21"), "+989151280270", "aliehaliabadi@gmail.com", "123456");

            _readService.ExistsByNAmeLastNameDateOfBirthAsync(command.Name, command.LastName, command.DateOfBirth).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<CustomerAlreadyExists>();
        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new CreateCustomer(Guid.NewGuid(),"Aliyeh","Aliabadi",Convert.ToDateTime("1987/10/21"),"+989151280270","aliehaliabadi@gmail.com","123456");

            _readService.ExistsByEmailAsync(command.Name).Returns(false);
            _readService.ExistsByNAmeLastNameDateOfBirthAsync(command.Name,command.LastName,command.DateOfBirth).Returns(false);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<Customer>());
        }

        #region ARRANGE

        private readonly ICommandHandler<CreateCustomer> _commandHandler;
        private readonly ICustomerRepository _repository;
        private readonly ICustomerReadService _readService;
        private readonly ICustomerFactory _factory;

        public CreateCustomerHandlerTest()
        {
            _repository = Substitute.For<ICustomerRepository>();
            _readService = Substitute.For<ICustomerReadService>();
            _factory = Substitute.For<ICustomerFactory>();
            _commandHandler = new CreateCustomerHandler(_repository, _factory,_readService);
        }

        #endregion 
    }
}
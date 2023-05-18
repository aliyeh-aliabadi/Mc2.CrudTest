using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public CustomerId Id { get; private set; }
        private CustomerFirstName _name;
        private CustomerLastName _lastName;
        private CustomerDateOfBirth _dateOfBirth;
        private CustomerPhoneNumber _phoneNumber;
        private CustomerEmail _email;
        private CustomerBankAccountNumber _bankAccountNumber;

        internal Customer(CustomerId id,
           CustomerFirstName name,
           CustomerLastName lastName,
           CustomerDateOfBirth dateOfBirth,
           CustomerPhoneNumber customerPhoneNumber,
           CustomerEmail email,
           CustomerBankAccountNumber bankAccountNumber)
        {
            Id = id;
            _name = name;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _phoneNumber = customerPhoneNumber;
            _email = email;
            _bankAccountNumber = bankAccountNumber;
        }
        public Customer() { }
    }
}

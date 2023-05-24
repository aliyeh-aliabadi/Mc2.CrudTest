using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Factories
{
    public sealed class CustomerFactory : ICustomerFactory
    {
        public Customer Create(CustomerId id, CustomerFirstName name, CustomerLastName lastName, CustomerDateOfBirth dateOfBirth, 
            CustomerPhoneNumber phoneNumber, CustomerEmail email, CustomerBankAccount bankAccount)
        => new (id,name,lastName,dateOfBirth,phoneNumber,email,bankAccount);
    }
}

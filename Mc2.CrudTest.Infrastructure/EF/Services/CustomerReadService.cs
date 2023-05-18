using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Infrastructure.EF.Context;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.EF.Services
{
    public class CustomerReadService : ICustomerReadService
    {
        private readonly DbSet<CustomerModel> _customer;
        public CustomerReadService(ReadDbContext context)
            => _customer = context.Customers;
        public Task<bool> ExistsByEmailAsync(string email)
          => _customer.AnyAsync(c => c.Email == email);

        public Task<bool> ExistsByNAmeLastNameDateOfBirthAsync(string name, string lastName, DateTime dateOfBirth)
         => _customer.AnyAsync(c => c.Name == name && c.LastName == lastName && c.DateOfBirth == dateOfBirth);
    }
}

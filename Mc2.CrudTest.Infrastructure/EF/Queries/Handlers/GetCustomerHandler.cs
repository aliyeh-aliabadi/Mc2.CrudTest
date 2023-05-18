using Mc2.CrudTest.Application.Dto;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Infrastructure.EF.Context;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Mc2.CrudTest.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly DbSet<CustomerModel> _customer;

        public GetCustomerHandler(ReadDbContext context)
            => _customer = context.Customers;

        public Task<CustomerDto> HandleAsync(GetCustomer query)
            => _customer
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}

using Mc2.CrudTest.Application.Dto;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Mc2.CrudTest.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        public Task<CustomerDto> HandleAsync(GetCustomer query)
        {
            throw new NotImplementedException();
        }
    }
}

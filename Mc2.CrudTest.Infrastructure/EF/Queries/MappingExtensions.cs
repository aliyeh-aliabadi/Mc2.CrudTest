using Mc2.CrudTest.Application.Dto;
using Mc2.CrudTest.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.EF.Queries
{
    public static class MappingExtensions
    {
        public static CustomerDto AsDto(this CustomerModel readModel)
          => new()
          {
              Id = readModel.Id,
              Name = readModel.Name,
              LastName = readModel.LastName,
              DateOfBirth = readModel.DateOfBirth,
              BankAccount = readModel.BankAccount,
              Email = readModel.Email,
              PhoneNumber = readModel.PhoneNumber
          };
    }
}

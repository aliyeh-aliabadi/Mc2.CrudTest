using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Dto;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Shared.Abstractions.Commands;
using Mc2.CrudTest.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CustomerController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomer query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPut("customer")]
        public async Task<IActionResult> Put([FromBody] UpdateCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] RemoveCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}

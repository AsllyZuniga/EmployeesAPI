using Employees.Application.Contracts.Commands;
using Employees.Application.Contracts.Queries;
using Employees.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contracts = await _mediator.Send(new GetContractsQuery());
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var contract = await _mediator.Send(new GetContractByIdQuery(id));

            if (contract is null)
                return NotFound();

            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractRequest request)
        {
            var command = new CreateContractCommand(
                request.EmployeeId,
                request.ContractNumber,
                request.StartDate,
                request.EndDate,
                request.Salary,
                request.ContractType
            );

            var contractId = await _mediator.Send(command);

            return Ok(contractId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _mediator.Send(new DeleteContractCommand(id));

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}

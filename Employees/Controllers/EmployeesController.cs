using Employees.Application.Employees.Commands;
using Employees.Application.Employees.Queries;
using Employees.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var command = new CreateEmployeeCommand(
                request.FullName,
                request.Identification,
                request.Email,
                request.Phone
            );

            var employeeId = await _mediator.Send(command);

            return Ok(employeeId);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _mediator.Send(new DeleteEmployeeCommand(id));

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
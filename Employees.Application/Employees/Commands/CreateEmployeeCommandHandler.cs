using Employees.Application.Employees.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Employees.Commands;

public sealed class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, long>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<long> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee(
            request.FullName,
            request.Identification,
            request.Email,
            request.Phone);

        await _employeeRepository.CreateAsync(employee, cancellationToken);

        return employee.Id;
    }
}
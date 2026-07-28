using Employees.Application.Employees.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Employees.Queries;

public sealed class GetEmployeeByIdQueryHandler
    : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee?> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}

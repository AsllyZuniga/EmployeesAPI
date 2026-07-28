using Employees.Application.Employees.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Employees.Queries;

public sealed class GetEmployeesQueryHandler
    : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetAllAsync(cancellationToken);
    }
}

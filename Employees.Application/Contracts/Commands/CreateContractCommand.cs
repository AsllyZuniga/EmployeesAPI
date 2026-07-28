using MediatR;

namespace Employees.Application.Contracts.Commands;

public sealed record CreateContractCommand(
    long EmployeeId,
    string ContractNumber,
    DateTime StartDate,
    DateTime? EndDate,
    decimal Salary,
    string ContractType
) : IRequest<long>;

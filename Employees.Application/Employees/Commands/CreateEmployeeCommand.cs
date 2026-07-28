using MediatR;

namespace Employees.Application.Employees.Commands;

public sealed record CreateEmployeeCommand(
    string FullName,
    string Identification,
    string Email,
    string Phone
) : IRequest<long>;
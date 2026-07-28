using MediatR;

namespace Employees.Application.Employees.Commands;

public sealed record DeleteEmployeeCommand(long Id) : IRequest<bool>;

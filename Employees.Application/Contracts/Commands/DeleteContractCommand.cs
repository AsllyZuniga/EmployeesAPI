using MediatR;

namespace Employees.Application.Contracts.Commands;

public sealed record DeleteContractCommand(long Id) : IRequest<bool>;

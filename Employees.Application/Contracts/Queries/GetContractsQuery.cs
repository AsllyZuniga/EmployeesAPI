using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Contracts.Queries;

public sealed record GetContractsQuery() : IRequest<IEnumerable<Contract>>;

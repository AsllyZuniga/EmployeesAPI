using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Contracts.Queries;

public sealed record GetContractByIdQuery(long Id) : IRequest<Contract?>;

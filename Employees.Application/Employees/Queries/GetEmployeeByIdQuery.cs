using MediatR;
using Employees.Domain.Entities;

namespace Employees.Application.Employees.Queries;

public sealed record GetEmployeeByIdQuery(long Id) : IRequest<Employee?>;

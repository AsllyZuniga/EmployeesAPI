using Employees.Application.Contracts.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Contracts.Queries;

public sealed class GetContractByIdQueryHandler
    : IRequestHandler<GetContractByIdQuery, Contract?>
{
    private readonly IContractRepository _contractRepository;

    public GetContractByIdQueryHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<Contract?> Handle(
        GetContractByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _contractRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}

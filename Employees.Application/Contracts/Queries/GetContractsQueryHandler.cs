using Employees.Application.Contracts.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Contracts.Queries;

public sealed class GetContractsQueryHandler
    : IRequestHandler<GetContractsQuery, IEnumerable<Contract>>
{
    private readonly IContractRepository _contractRepository;

    public GetContractsQueryHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<IEnumerable<Contract>> Handle(
        GetContractsQuery request,
        CancellationToken cancellationToken)
    {
        return await _contractRepository.GetAllAsync(cancellationToken);
    }
}

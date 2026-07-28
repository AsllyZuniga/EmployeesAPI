using Employees.Application.Contracts.Interfaces;
using MediatR;

namespace Employees.Application.Contracts.Commands;

public sealed class DeleteContractCommandHandler
    : IRequestHandler<DeleteContractCommand, bool>
{
    private readonly IContractRepository _contractRepository;

    public DeleteContractCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<bool> Handle(
        DeleteContractCommand request,
        CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.Id, cancellationToken);

        if (contract is null)
            return false;

        await _contractRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}

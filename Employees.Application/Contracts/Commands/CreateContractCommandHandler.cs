using Employees.Application.Contracts.Interfaces;
using Employees.Domain.Entities;
using MediatR;

namespace Employees.Application.Contracts.Commands;

public sealed class CreateContractCommandHandler
    : IRequestHandler<CreateContractCommand, long>
{
    private readonly IContractRepository _contractRepository;

    public CreateContractCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<long> Handle(
        CreateContractCommand request,
        CancellationToken cancellationToken)
    {
        var contract = new Contract(
            request.EmployeeId,
            request.ContractNumber,
            request.StartDate,
            request.EndDate,
            request.Salary,
            request.ContractType);

        await _contractRepository.CreateAsync(contract, cancellationToken);

        return contract.Id;
    }
}

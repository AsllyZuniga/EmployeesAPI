using Employees.Domain.Entities;

namespace Employees.Application.Contracts.Interfaces;

public interface IContractRepository
{
    Task CreateAsync(Contract contract, CancellationToken cancellationToken);

    Task<IEnumerable<Contract>> GetAllAsync(CancellationToken cancellationToken);

    Task<Contract?> GetByIdAsync(long id, CancellationToken cancellationToken);

    Task DeleteAsync(long id, CancellationToken cancellationToken);
}

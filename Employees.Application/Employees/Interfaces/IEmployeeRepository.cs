using Employees.Domain.Entities;

namespace Employees.Application.Employees.Interfaces;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee, CancellationToken cancellationToken);

    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(long id, CancellationToken cancellationToken);

    Task DeleteAsync(long id, CancellationToken cancellationToken);
}
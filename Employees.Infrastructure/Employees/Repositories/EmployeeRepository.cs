using Dapper;
using Employees.Application.Employees.Interfaces;
using Employees.Domain.Entities;
using System.Data;

namespace Employees.Infrastructure.Employees.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbConnection _connection;

    public EmployeeRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        const string sql = "SELECT Id, FullName, Identification, Email, Phone FROM EMPLOYEES";

        return await _connection.QueryAsync<Employee>(sql);
    }

    public async Task<Employee?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        const string sql = "SELECT Id, FullName, Identification, Email, Phone FROM EMPLOYEES WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        const string sql = "DELETE FROM EMPLOYEES WHERE Id = @Id";

        await _connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task CreateAsync(Employee employee, CancellationToken cancellationToken)
    {
        const string sql = @"
INSERT INTO EMPLOYEES
(
    FullName,
    Identification,
    Email,
    Phone
)
VALUES
(
    @FullName,
    @Identification,
    @Email,
    @Phone
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";

        var id = await _connection.QuerySingleAsync<long>(sql, employee);
        employee.Id = id;
    }
}
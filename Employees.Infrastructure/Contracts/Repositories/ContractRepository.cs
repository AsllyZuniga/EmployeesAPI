using Dapper;
using Employees.Application.Contracts.Interfaces;
using Employees.Domain.Entities;
using System.Data;

namespace Employees.Infrastructure.Contracts.Repositories;

public class ContractRepository : IContractRepository
{
    private readonly IDbConnection _connection;

    public ContractRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Contract>> GetAllAsync(CancellationToken cancellationToken)
    {
        const string sql = "SELECT Id, EmployeeId, ContractNumber, StartDate, EndDate, Salary, ContractType FROM CONTRACTS";

        return await _connection.QueryAsync<Contract>(sql);
    }

    public async Task<Contract?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        const string sql = "SELECT Id, EmployeeId, ContractNumber, StartDate, EndDate, Salary, ContractType FROM CONTRACTS WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Contract>(sql, new { Id = id });
    }

    public async Task CreateAsync(Contract contract, CancellationToken cancellationToken)
    {
        const string sql = @"
INSERT INTO CONTRACTS
(
    EmployeeId,
    ContractNumber,
    StartDate,
    EndDate,
    Salary,
    ContractType
)
VALUES
(
    @EmployeeId,
    @ContractNumber,
    @StartDate,
    @EndDate,
    @Salary,
    @ContractType
);

SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";

        var id = await _connection.QuerySingleAsync<long>(sql, contract);
        contract.Id = id;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        const string sql = "DELETE FROM CONTRACTS WHERE Id = @Id";

        await _connection.ExecuteAsync(sql, new { Id = id });
    }
}

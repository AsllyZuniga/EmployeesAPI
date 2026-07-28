namespace Employees.Requests;

public sealed record CreateContractRequest(
    long EmployeeId,
    string ContractNumber,
    DateTime StartDate,
    DateTime? EndDate,
    decimal Salary,
    string ContractType
);

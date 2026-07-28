namespace Employees.Requests
{
    public sealed record CreateEmployeeRequest(
        string FullName,
        string Identification,
        string Email,
        string Phone
    );
    
}

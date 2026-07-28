using Employees.Application.Contracts.Interfaces;
using Employees.Application.Employees.Interfaces;
using Employees.Infrastructure.Contracts.Repositories;
using Employees.Infrastructure.Employees.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Employees.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        services.AddScoped<IContractRepository, ContractRepository>();

        return services;
    }
}
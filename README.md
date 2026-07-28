# EmployeesAPI

RESTful API for managing employees and employment contracts, built with ASP.NET Core following Clean Architecture and CQRS patterns.

## Architecture

The solution is organized into four projects following Clean Architecture principles:

```
Employees.Domain/         Core entities and business logic
Employees.Application/    CQRS commands, queries, and handlers
Employees.Infrastructure/ Data access with Dapper and ADO.NET
Employees/                ASP.NET Core Web API (presentation layer)
```

## Technologies

- **.NET 8** with ASP.NET Core
- **CQRS** pattern via MediatR
- **Dapper** for lightweight data access
- **ADO.NET** with SQL Server
- **Postman** for API testing

## Entities

### Employee

| Property       | Type   |
|----------------|--------|
| Id             | long   |
| FullName       | string |
| Identification | string |
| Email          | string |
| Phone          | string |

### Contract

| Property     | Type     |
|--------------|----------|
| Id           | long     |
| EmployeeId   | long     |
| StartDate    | DateTime |
| EndDate      | DateTime |
| Salary       | decimal  |
| Position     | string   |
| ContractType | string   |

## API Endpoints

### Employees

| Method | Endpoint              | Description        |
|--------|-----------------------|--------------------|
| GET    | /api/employees        | Get all employees  |
| GET    | /api/employees/{id}   | Get employee by ID |
| POST   | /api/employees        | Create an employee |
| DELETE | /api/employees/{id}   | Delete an employee |

### Contracts

| Method | Endpoint                | Description          |
|--------|-------------------------|----------------------|
| GET    | /api/employees/{employeeId}/contracts | Get contracts by employee |
| GET    | /api/contracts/{id}     | Get contract by ID   |
| POST   | /api/contracts          | Create a contract    |
| DELETE | /api/contracts/{id}     | Delete a contract    |

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (local or remote)

### Configuration

Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EmployeesDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

For local development, override settings in `appsettings.Development.json` (this file is ignored by git).

### Run the application

```bash
cd Employees
dotnet run
```

The API will be available at `https://localhost:5001`. You can test the endpoints using Postman or any HTTP client.
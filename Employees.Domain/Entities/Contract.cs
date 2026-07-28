namespace Employees.Domain.Entities
{
    public sealed class Contract
    {
        private Contract()
        {
            ContractNumber = null!;
            ContractType = null!;
        }

        public Contract(
            long employeeId,
            string contractNumber,
            DateTime startDate,
            DateTime? endDate,
            decimal salary,
            string contractType)
        {
            EmployeeId = employeeId;
            ContractNumber = contractNumber;
            StartDate = startDate;
            EndDate = endDate;
            Salary = salary;
            ContractType = contractType;
        }

        public long Id { get; set; }

        public long EmployeeId { get; private set; }

        public string ContractNumber { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public decimal Salary { get; private set; }

        public string ContractType { get; private set; }
    }
}

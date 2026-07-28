namespace Employees.Domain.Entities
{
    public sealed class Employee
    {
        private Employee()
        {
            FullName = null!;
            Identification = null!;
            Email = null!;
            Phone = null!;
        }

        public Employee(
            string fullName,
            string identification,
            string email,
            string phone)
        {
            FullName = fullName;
            Identification = identification;
            Email = email;
            Phone = phone;
        }

        public long Id { get; set; }

        public string FullName { get; private set; }

        public string Identification { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }
    }
}
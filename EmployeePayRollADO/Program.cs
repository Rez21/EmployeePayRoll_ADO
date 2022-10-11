namespace EmployeePayRollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePayRoll model = new EmployeePayRoll()
            {
                Name = "Jay",
                Address = "lucknow",
                Phone = 987654,
                Salary = 26530.00
            };
            EmployeeRepository.AddEmployee(model);
            EmployeeRepository.GetAllEmployees();
            Console.ReadLine();
        }
    }
}
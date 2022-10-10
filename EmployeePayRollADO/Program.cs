namespace EmployeePayRollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository.GetAllEmployees();
            Console.ReadLine();
        }
    }
}
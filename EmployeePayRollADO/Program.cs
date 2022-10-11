namespace EmployeePayRollADO
{
    class Program
    {
        static void Main(string[] args)
        {   //------AddEmployeee---------
            //EmployeePayRoll model = new EmployeePayRoll()
            //{
            //    Name = "Jay",
            //    Address = "lucknow",
            //    Phone = 987654,
            //    Salary = 26530.00
            //};
            //EmployeeRepository.AddEmployee(model);

            //--------Update Eployee----------
            //EmployeePayRoll model = new EmployeePayRoll()
            //{
            //    Name = "Shakti",
            //    EmployeeID=2, 
            //   Salary = 65402.00
            //};
            //EmployeeRepository.UpdateEmployee(model);
            EmployeePayRoll model = new EmployeePayRoll()
            {
                Name = "Shakti",
                EmployeeID = 2,
              
            };
            EmployeeRepository.DeleteEmployee(model);
            EmployeeRepository.GetAllEmployees();
            Console.ReadLine();
        }
    }
}
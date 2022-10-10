using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollADO
{
    public class EmployeePayRoll
    {
        public int EmployeeID { get; set; }
        public int Phone { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public double TaxablePay { get; set; }
        public double NetPay { get; set; }
        public double IncomeTax { get; set; }
        public double Deductions { get; set; }


    }
}

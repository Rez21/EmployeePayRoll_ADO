using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollADO
{
    public class EmployeeRepository
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayrollService;trusted_connection=true";

        public static void GetAllEmployees()
        {
            SqlConnection connection = null;
            try
            {
                EmployeePayRoll model = new EmployeePayRoll();
                connection = new SqlConnection(connectionString);
                string query = "select * from EmployeePayRoll";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.EmployeeID = Convert.ToInt32(reader["EmployeeID"] == DBNull.Value ? default : reader["EmployeeID"]);
                        model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                        model.Salary = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                        model.StartDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                        model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                        model.Phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        model.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                        model.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                        model.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                        model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                        model.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);

                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", model.EmployeeID, model.Name, model.Salary, model.Gender, model.Phone, model.Address, model.Department, model.StartDate);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void AddEmployee(EmployeePayRoll model)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spAddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Salary", model.Salary);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Phone", model.Phone);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Added Successfully");
                else
                    Console.WriteLine("Something went wrong!!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void UpdateEmployee(EmployeePayRoll model)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Salary", model.Salary);
                command.Parameters.AddWithValue("@ID", model.EmployeeID);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Updated Successfully");
                else
                    Console.WriteLine("Something went wrong!!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void DeleteEmployee(EmployeePayRoll model)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spDeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@ID", model.EmployeeID);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Deleted Successfully");
                else
                    Console.WriteLine("Something went wrong!!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
}

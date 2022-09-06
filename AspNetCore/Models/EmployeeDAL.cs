using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AspNetCore.Models
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        private readonly IConfiguration configuration;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            string str = "select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee e = new Employee();
                    e.Id = Convert.ToInt32(reader["Id"]);
                    e.Name = reader["Name"].ToString();
                    e.Salary = Convert.ToDecimal(reader["Salary"]);
                    list.Add(e);
                }
            }
            con.Close();
            return list;
        }
        //public Employee GetEmployeeById()
        //{

        //}
        public int AddEmployee(Employee emp)
        {
            string str = "insert into Employee values(@name,@sal)";
            cmd = new SqlCommand(str,con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateEmployee(Employee emp)
        {
            string str = "update Employee set Name=@name, Salary=@sal where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        //public int DeleteEmployee(int id)
        //{

        //}


    }
}

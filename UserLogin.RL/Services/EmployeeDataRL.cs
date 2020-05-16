using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using CommonLayer.Model;
using System.Data;
using EmployeeRepository.Interface;
using EmployeeRepository.CL.Model;
using System.Threading.Tasks;

namespace EmployeeRepository.Services
{

    public class EmployeeDataRL : IEmployeeDataRL
    {
        /// <summary>
        /// 
        /// </summary>
        readonly string connectionString = "Data Source=LAPTOP-Q1S40S7K\\SAKSHAMSQL;Initial Catalog = Employee; User ID = sa; Integrated Security = True";
        
        /// <summary>
        /// API to get all employee details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = StoreProcedureConnection("spGetEmployees", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EmployeeModel employee = new EmployeeModel
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    City = reader["City"].ToString()
                };
                listEmployee.Add(employee);
            }
            connection.Close();
            return listEmployee;
        }

        /// <summary>
        /// API to register Employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns> if operation is successful or not </returns>
        public async Task<bool> Register(EmployeeModel model)
        {
            ResponseMessage<Type> response = new ResponseMessage<Type>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = StoreProcedureConnection("spRegisterEmployee", connection);
            command.Parameters.AddWithValue("FirstName", model.FirstName);
            command.Parameters.AddWithValue("LastName", model.LastName);
            command.Parameters.AddWithValue("Email", model.Email);
            command.Parameters.AddWithValue("UserName", model.UserName);
            command.Parameters.AddWithValue("Password", model.Password);
            command.Parameters.AddWithValue("City", model.City);
            connection.Open();
            var result = await command.ExecuteNonQueryAsync();
            connection.Close();
            if (!response.Equals(null))
            {
                response.IsSuccess = true ;
            }
            else
            {
                response.IsSuccess = false;
            }
            return response.IsSuccess;
        }


        public SqlCommand StoreProcedureConnection(string storeProcedureName, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(storeProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

    }
}

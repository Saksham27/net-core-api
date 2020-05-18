//-----------------------------------------------------------------------
// <copyright file="EmployeeDataRL.cs" company="BridgeLabz Solutions LLP">
//     Copyright (c) Company. All rights reserved.
// </copyright>
// <author> Saksham Singh </author>
//-----------------------------------------------------------------------
#region EmployeeRepository.Services
namespace EmployeeRepository.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using CommonLayer.Model;
    using System.Data;
    using EmployeeRepository.Interface;
    using EmployeeRepository.CL.Model;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;

    #region EmployeeDataRL
    /// <summary>
    /// class containing All the CRUD operation and more API
    /// </summary>
    public class EmployeeDataRL : IEmployeeDataRL
    {
        private readonly IConfiguration configuration;

        public EmployeeDataRL(IConfiguration configure)
        {
            configuration = configure;
        }

        /// <summary>
        /// API to get all employee details
        /// </summary>
        /// <returns></returns>
        #region GetAllEmployeeDetails
        public IEnumerable<EmployeeModel> GetAllEmployeeDetails()
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            SqlConnection connection = DatabaseConnection();
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
        #endregion GetAllEmployeeDetails

        /// <summary>C:\Users\Saksham\source\repos\UserLogin.Api\UserLogin.RL\Services\EmployeeDataRL.cs
        /// API to register Employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns> if operation is successful or not </returns>
        #region RegisterEmployee
        public int RegisterEmployee(EmployeeModel model)
        {
            SqlConnection connection = DatabaseConnection();

            try
            {
                SqlCommand command = StoreProcedureConnection("spRegisterEmployee", connection);
                command.Parameters.AddWithValue("FirstName", model.FirstName);
                command.Parameters.AddWithValue("LastName", model.LastName);
                command.Parameters.AddWithValue("Email", model.Email);
                command.Parameters.AddWithValue("UserName", model.UserName);
                command.Parameters.AddWithValue("Password", model.Password);
                command.Parameters.AddWithValue("City", model.City);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            { 
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion RegisterEmployee

        /// <summary>
        /// API to Get details of specfic employee
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        #region GetEmployeeDetails
        public IEnumerable<EmployeeModel> GetEmployeeDetails(string inputData)
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            SqlConnection connection = DatabaseConnection();
            SqlCommand command = StoreProcedureConnection("spGetEmployeeDetail", connection);
            command.Parameters.Add("@Data", SqlDbType.VarChar, 50).Value = inputData;
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
        #endregion GetEmployeeDetails

        /// <summary>
        /// API to details of specfid employee with Id
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        #region GetEmployeeDetailsWithId
        public IEnumerable<EmployeeModel> GetEmployeeDetailsWithId(EmployeeId inputData)
        {
            List<EmployeeModel> listEmployee = new List<EmployeeModel>();
            SqlConnection connection = DatabaseConnection();
            SqlCommand command = StoreProcedureConnection("spGetEmployeeDetailWithId", connection);
            command.Parameters.Add("@Id", SqlDbType.Int, 50).Value = inputData.ID;
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
        #endregion GetEmployeeDetailsWithId

        /// <summary>
        /// API to Delete employee from databse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region DeleteEmployee
        public int DeleteEmployee(EmployeeId inputId)
        {
            SqlConnection connection = DatabaseConnection();
            try
            {
                SqlCommand command = StoreProcedureConnection("spDeleteEmployeeDetail", connection);
                command.Parameters.Add("@Id", SqlDbType.Int, 50).Value = inputId.ID;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion DeleteEmployee

        /// <summary>
        /// API for employee Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        #region Login
        public int EmployeeLogin(LoginModel loginData)
        {
            SqlConnection connection = DatabaseConnection();
            try
            {
                SqlCommand command = StoreProcedureConnection("spLoginEmployee", connection);
                command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = loginData.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = loginData.Password;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion Login

        /// <summary>
        /// API to update employee details
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        #region UpdateEmployeeDetails
        public int UpdateEmployeeDetails(UpdateModel data)
        {
            SqlConnection connection = DatabaseConnection();
            try
            {
                UpdateModel employee = new UpdateModel();
               
                SqlCommand command = StoreProcedureConnection("spUpdateEmployeeDetails", connection);
                command.Parameters.AddWithValue("@EmployeeId", data.EmployeeId);
                command.Parameters.AddWithValue("@FirstName", data.FirstName);
                command.Parameters.AddWithValue("@LastName", data.LastName);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@UserName", data.UserName);
                command.Parameters.AddWithValue("@Password", data.Password);
                command.Parameters.AddWithValue("@City", data.City);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion UpdateEmployeeDetails

        /// <summary>
        ///  database connection with connection string
        /// </summary>
        private SqlConnection DatabaseConnection()
        {
            //connection string
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeData").Value;
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Generic method to use stored procedure
        /// </summary>
        /// <param name="storeProcedureName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        #region StoreProcedureConnection
        public SqlCommand StoreProcedureConnection(string storeProcedureName, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(storeProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        #endregion StoreProcedureConnection
    }
    #endregion EmployeeDataRL
}
#endregion EmployeeRepository.Services
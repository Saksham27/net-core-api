using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using EmployeeRepository.Interface;
using EmployeeRepository.CL.Model;
using System.Linq;

namespace BusinessLayer.Services
{
    public class EmployeeDataBL : Interface.IEmployeeDataBL
    {
        private IEmployeeDataRL employeeRepository;
        public EmployeeDataBL(IEmployeeDataRL employeeRepo)
        {
            employeeRepository = employeeRepo;
        }

        public ResponseMessage GetAllEmployeeDetails()
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                List<EmployeeModel> data = employeeRepository.GetAllEmployeeDetails().ToList();
                if (data is null)
                {
                    response.Status = false;
                    response.Message = "Its lonely here. No employee exists.";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Here is all employees details.";
                    response.ReturnData = data;
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public ResponseMessage RegisterEmployee(EmployeeModel data)
        {
            
            try
            {
                ResponseMessage response = new ResponseMessage();
                int registrationStatus = employeeRepository.RegisterEmployee(data);
                if (registrationStatus > 0)
                {
                    response.Status = true;
                    response.Message = "Registration successful.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Registration failed. This Email Id or username already exists.";
                }
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ResponseMessage EmployeeLoginBL(LoginModel loginData)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                int  loginStatus = employeeRepository.EmployeeLogin(loginData);
                if (loginStatus == 1)
                {
                    response.Status = true;
                    response.Message = "Login successful.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Login failed.";
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseMessage GetEmployeeDetails(string inputData)
        {
            ResponseMessage response = new ResponseMessage();
            List<EmployeeModel> data = employeeRepository.GetEmployeeDetails(inputData).ToList();
            if (data.Count == 0)
            {
                response.Status = false;
                response.Message = "No such employee exists.";

            }
            else
            {
                response.Status = true;
                response.Message = "Employee found. Here are the details";
                response.ReturnData = data;
            }
            return response;
        }

        public ResponseMessage GetEmployeeDetailsWithId(EmployeeId inputData)
        {
            ResponseMessage response = new ResponseMessage();
            List<EmployeeModel> data = employeeRepository.GetEmployeeDetailsWithId(inputData).ToList();
            if (data.Count ==0)
            {
                response.Status = false;
                response.Message = "No such employee exists.";

            }
            else
            {
                response.Status = true;
                response.Message = "Employee found. Here are the details";
                response.ReturnData = data;
            }
            return response;
        }

        public ResponseMessage DeleteEmployee(EmployeeId id)
        {
            ResponseMessage response = new ResponseMessage();
            int deletionStatus = employeeRepository.DeleteEmployee(id);
            if (deletionStatus == 1)
            {
                response.Status = true;
                response.Message = "employee data successfully deleted.";

            }
            else
            {
                response.Status = false;
                response.Message = "No such employee exists.";
            }
            return response;
        }

        public ResponseMessage UpdateEmployeeDetails(UpdateModel data)
        {
            ResponseMessage response = new ResponseMessage();
            int updationStatus = (employeeRepository.UpdateEmployeeDetails(data));
            if(updationStatus == 1)
            {
                response.Status = true;
                response.Message = "Employee details updated.";
            }
            else
            {
                response.Status = false;
                response.Message = "No such employee exists.";
            }
            return response;
        }
    }
}

using CommonLayer.Model;
using EmployeeRepository.CL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeDataBL
    {
        ResponseMessage GetAllEmployeeDetails();
        ResponseMessage RegisterEmployee(EmployeeModel model);
        ResponseMessage EmployeeLoginBL(LoginModel loginData);
        ResponseMessage GetEmployeeDetails(string inputData);
        ResponseMessage GetEmployeeDetailsWithId(EmployeeId inputData);
        ResponseMessage UpdateEmployeeDetails(UpdateModel data);
        ResponseMessage DeleteEmployee(EmployeeId id);
    }
}

using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEmployeeDataBL.Interface
{
    public interface IEmployeeDataBL
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        Task<bool> Register(EmployeeModel model);
    }
}

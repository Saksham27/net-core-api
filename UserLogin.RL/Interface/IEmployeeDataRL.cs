using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository.Interface
{
    public interface IEmployeeDataRL
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        Task<bool> Register(EmployeeModel model);
    }
}

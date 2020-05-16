using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IEmployeeDataBL.Interface;
using CommonLayer.Model;
using EmployeeRepository.Interface;

namespace IEmployeeDataBL.Services
{
    class EmployeeDataBL : Interface.IEmployeeDataBL
    {
        private IEmployeeDataRL employeeRepository;
        public EmployeeDataBL(IEmployeeDataRL employeeRepo)
        {
            employeeRepository = employeeRepo;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                var result = employeeRepository.GetAllEmployees();
                if (result.Equals(null))
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> Register(EmployeeModel data)
        {
            try
            {
                var Result = await employeeRepository.Register(data);
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

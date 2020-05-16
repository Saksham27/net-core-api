using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using EmployeeRepository.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using CommonLayer.Model;
using IEmployeeDataBL.Interface;

namespace UserLogin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDataRL empObj = new EmployeeDataRL();

        
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            listEmp = empObj.GetAllEmployees().ToList();

            return Ok(listEmp);
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] EmployeeModel model)
        {
            try
            {
                bool data = await empObj.Register(model);
                if (!data.Equals(null))
                {
                    bool status = true;
                    var message = "Registration Successful";
                    return this.Ok(new { status, message });
                }
                else
                {
                    bool status = false;
                    var message = "Registration failed";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }
    }
}
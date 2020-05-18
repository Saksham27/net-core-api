using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeRepository.CL.Model
{
    [DataContract]
    public class ResponseMessage 
    {
        [DataMember(Name = "IsSuccess")]
        public bool Status { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string Message { get; set; }

        [DataMember(Name = "ReturnData")]
        public List<EmployeeModel> ReturnData { get; set; } = null;
    }
}

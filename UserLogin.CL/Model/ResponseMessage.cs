using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeRepository.CL.Model
{
    [DataContract]
    public class ResponseMessage<Type> 
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "ReturnData")]
        public EmployeeModel ReturnData { get; set; }
    }
}

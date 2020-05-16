using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CommonLayer.Model
{
    [DataContract]
    public class EmployeeModel
    {
        [DataMember(Name = "EmployeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "UserName")]
        public string UserName { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }
    }
}

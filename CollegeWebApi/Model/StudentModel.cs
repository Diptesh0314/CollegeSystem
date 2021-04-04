using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Runtime.Serialization;
//using System.Text.Json.Serialization;

namespace CollegeWebApi.Model
{
    //[DataContract]
    public class StudentModel
    {
        // [DataMember(Name = "StudentId")]
        //[JsonPropertyName("OTP")]
        public int StudentId { get; set; }
        //[JsonPropertyName("OTP")]
        //[DataMember(Name = "StudentName")]
        public string StudentName { get; set; }
        //[JsonPropertyName("OTP")]
        // [DataMember(Name = "BranchName")]
        public string BranchName { get; set; }

       
    }
}

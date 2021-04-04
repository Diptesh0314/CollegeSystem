using System;
using System.Runtime.Serialization;
namespace CollegeSystem.Entity
{
    //[DataContract]
    public class Student
    {
        //[DataMember(Name = "StudentId")]
        public int StudentId { get; set; }

       // [DataMember(Name = "StudentName")]
        public string StudentName { get; set; }

       // [DataMember(Name = "BranchName")]
        public string BranchName { get; set; }

    }
}

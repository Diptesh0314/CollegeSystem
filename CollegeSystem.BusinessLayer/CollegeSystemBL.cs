using System;
using System.Data;
using System.Collections.Generic;
using CollegeSystem.Entity;
using CollegeSystem.DataAccesssLayer;
namespace CollegeSystem.BusinessLayer
{
    public class CollegeSystemBL
    {
        CollegeSystemDAL collegeSystemDAL = new CollegeSystemDAL();
            public int AddStudent(Student student)
            {
              int rows= collegeSystemDAL.AddStudent(student);
              return rows;
            }
        public List<Student> GetData()
        {
            List<Student> students = collegeSystemDAL.GetData();
            return students;
        }
        public int EditStudent(Student student)
        {
            int rows=collegeSystemDAL.EditStudent(student);
            return rows;
        }


    }
}

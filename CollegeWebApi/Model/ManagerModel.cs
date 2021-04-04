using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using CollegeSystem.Entity;
using CollegeSystem.BusinessLayer;
namespace CollegeWebApi.Model
{
    public class ManagerModel
    {
        CollegeSystemBL collegeSystemBL = new CollegeSystemBL();
        public int AddStudent(StudentModel studentModel)
        {
            Student student = new Student();
            student.StudentName = studentModel.StudentName;
            student.BranchName = studentModel.BranchName;
            int rows = collegeSystemBL.AddStudent(student);
            return rows;
        }
        public StudentModel StudentToModel(Student student)
        {
            StudentModel studentModel = new StudentModel();
            studentModel.StudentId = student.StudentId;
            studentModel.StudentName = student.StudentName;
            studentModel.BranchName = student.BranchName;
            return studentModel;

        }
        public Student ModelToStudent(StudentModel studentModel)
        {
            Student student = new Student();
            student.StudentId = studentModel.StudentId;
            student.StudentName = studentModel.StudentName;
            student.BranchName = studentModel.BranchName;
            return student;

        }
        public List<StudentModel> GetData()
        {
            List<Student> students = collegeSystemBL.GetData();
            List<StudentModel> studentModels = new List<StudentModel>();
            foreach(Student student in students)
            {
                studentModels.Add(StudentToModel(student));
            }
            return studentModels;
        }
        public int EditStudent(StudentModel studentModel)
        {
            int rows = collegeSystemBL.EditStudent(ModelToStudent(studentModel));
            return rows;
        }
    }
}

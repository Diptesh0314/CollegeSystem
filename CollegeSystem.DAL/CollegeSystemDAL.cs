using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using CollegeSystem.Entity;
namespace CollegeSystem.DataAccesssLayer
{
    public class CollegeSystemDAL
    {
        string ConnectionString = "data source=.; database=CollegeSystem; integrated security=SSPI";
        public List<Student> GetData()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM Students;";
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(ConnectionString))
                {
                    myCon.Open();
                    using (SqlCommand command = new SqlCommand(query, myCon))
                    {
                        myReader = command.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                Student student = new Student();
                                student.StudentId = Convert.ToInt32(myReader["StudentId"]);
                                student.StudentName = myReader["StudentName"].ToString();
                                student.BranchName = myReader["BranchName"].ToString();
                                students.Add(student);
                            }
                        }

                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return students;

        }
        public int AddStudent(Student student)
        {
            int rows = -1;
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("stInsertStudent", connection);
                connection.Open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentName", student.StudentName);
                command.Parameters.AddWithValue("@BranchName", student.BranchName);

                rows = command.ExecuteNonQuery();


                command.Dispose();
                connection.Close();
                connection.Dispose();

            }
            catch (Exception ex)
            {

            }


            return rows;


        }


        public int EditStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("stEditStudents", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@StudentId", student.StudentId);
            command.Parameters.AddWithValue("@StudentName", student.StudentName);
            command.Parameters.AddWithValue("@BranchName", student.BranchName);
            connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return rows;
        }

    }
}

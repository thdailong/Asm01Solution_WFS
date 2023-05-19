using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class EnrollmentDAO
    {
        SqlConnection connection;
        SqlCommand command;
        public List<Enrollment> getAllCourse()
        {
            List<Enrollment> result = new List<Enrollment>();
            connection = _connect.makeConnect();
            string sql = "Select * from Enrollment";
            command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result.Add(new Enrollment
                        {
                            EnrollmentID = reader.GetInt32("EnrollmentID"),
                            CourseID = reader.GetInt32("CourseID"),
                            StudentID = reader.GetInt32("StudentID"),
                            Grade = reader.GetInt32("Grade")
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public void addEnrollment(Enrollment enrollment)
        {
            connection = _connect.makeConnect();
            command = new SqlCommand("Insert Enrollment values(@CourseID, @StudentID, @Grade)", connection);
            command.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
            command.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
            command.Parameters.AddWithValue("@Grade", enrollment.Grade);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void updateEnrollment(Enrollment enrollment)
        {
            connection = _connect.makeConnect();
            string SQL = "Update Enrollment set CourseID=@CourseID, StudentID=@StudentID, Grade=@Grade where EnrollmentID=@EnrollmentID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentID);
            command.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
            command.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
            command.Parameters.AddWithValue("@Grade", enrollment.Grade);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void deleteEnrollment(Enrollment enrollment)
        {
            connection = _connect.makeConnect();
            string SQL = "Delete Enrollment where EnrollmentID=@EnrollmentID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

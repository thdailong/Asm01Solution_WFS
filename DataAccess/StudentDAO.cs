using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class StudentDAO
    {
        SqlConnection connection;
        SqlCommand command;
        public List<Student> getAllCourse()
        {
            List<Student> result = new List<Student>();
            connection = _connect.makeConnect();
            string sql = "Select * from Student";
            command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result.Add(new Student
                        {
                            ID = reader.GetInt32("ID"),
                            LastName = reader.GetString("LastName"),
                            FirstMidName = reader.GetString("FirstMidName"),
                            EnrollmentDate = reader.GetDateTime("EnrollmentDate")
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

        public void addStudent(Student student)
        {
            connection = _connect.makeConnect();
            command = new SqlCommand("Insert Student values(@LastName, @FirstMidName, @EnrollmentDate)", connection);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@FirstMidName", student.FirstMidName);
            command.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
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
        public void updateCourse(Student student)
        {
            connection = _connect.makeConnect();
            string SQL = "Update Student set LastName=@LastName, FirstMidName=@FirstMidName, EnrollmentDate=@EnrollmentDate  where ID=@ID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", student.ID);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@FirstMidName", student.FirstMidName);
            command.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
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

        public void deleteCourse(Student student)
        {
            connection = _connect.makeConnect();
            string SQL = "Delete Student where ID=@ID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@ID", student.ID);
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

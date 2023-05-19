using System;
using System.Collections.Generic;
using System.Data;
using BusinessObject;
using Microsoft.Data.SqlClient;

namespace DataAccess
{

    public class CourseDAO
    {
        SqlConnection connection;
        SqlCommand command;
        public List<Course> getAllCourse()
        {
            List<Course> result = new List<Course>();
            connection = _connect.makeConnect();
            string sql = "Select * from Course";
            command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result.Add(new Course
                        {
                            CourseID = reader.GetInt32("CourseID"),
                            Title = reader.GetString("Title"),
                            Credits = reader.GetInt32("Credits")
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

        public void addCourse(Course course)
        {
            connection = _connect.makeConnect();
            command = new SqlCommand("Insert Course values(@Title, @Credits)", connection);
            command.Parameters.AddWithValue("@Title", course.Title);
            command.Parameters.AddWithValue("@Credits", course.Credits);
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
        public void updateCourse(Course course)
        {
            connection = _connect.makeConnect();
            string SQL = "Update Course set Title=@Title, Credits=@Credits  where CourseID=@CourseID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@Title", course.Title);
            command.Parameters.AddWithValue("@Credits", course.Credits);
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

        public void deleteCourse(Course course)
        {
            connection = _connect.makeConnect();
            string SQL = "Delete Course where CourseID=@CourseID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@CourseID", course.CourseID);
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

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class CourseController
    {
            public async Task<List<Course>> GetAllCoursesAsync()
            {
                var courses = new List<Course>();
                using (var conn = DBConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("SELECT * FROM Courses", conn);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courses.Add(new Course
                            {
                                CourseID = reader.GetInt32(0),
                                CourseName = reader.GetString(1)
                            });
                        }
                    }
                }
                return courses;
            }

            public async Task AddCourseAsync(Course course)
            {
                using (var conn = DBConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("INSERT INTO Courses (CourseName) VALUES (@name)", conn);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            public async Task UpdateCourseAsync(Course course)
            {
                using (var conn = DBConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("UPDATE Courses SET CourseName = @name WHERE CourseID = @id", conn);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@id", course.CourseID);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            public async Task DeleteCourseAsync(int courseId)
            {
                using (var conn = DBConfig.GetConnection())
                {
                    var cmd = new SQLiteCommand("DELETE FROM Courses WHERE CourseID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", courseId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }




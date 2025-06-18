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
    internal class StudentController
    {
        public async Task<List<Student>> GetAllAsync()
        {
            var list = new List<Student>();
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Students", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new Student
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            CourseID = reader.GetInt32(2)
                        });
                    }
                }
            }
            return list;
        }

        public async Task<Student> GetStudentByNameAsync(string name)
        {
            var all = await GetAllAsync();
            return all.FirstOrDefault(s => s.StudentName.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        public async Task AddAsync(Student student)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Students (Name, CourseID) VALUES (@name, @course)", conn);
                cmd.Parameters.AddWithValue("@name", student.StudentName);
                cmd.Parameters.AddWithValue("@course", student.CourseID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Student student)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Students SET Name = @name, CourseID = @course WHERE StudentID = @id", conn);
                cmd.Parameters.AddWithValue("@name", student.StudentName);
                cmd.Parameters.AddWithValue("@course", student.CourseID);
                cmd.Parameters.AddWithValue("@id", student.StudentId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Students WHERE StudentID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }




    }
}


  
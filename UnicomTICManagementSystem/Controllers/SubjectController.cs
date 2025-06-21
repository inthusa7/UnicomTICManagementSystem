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
    internal class SubjectController
    {
        public async Task<List<Subject>> GetAllAsync()
        { 
            var list = new List<Subject>();
            using (var conn = DBConfig.GetConnection())
            { 
                var cmd = new SQLiteCommand("SELECT * FROM Subjects", conn);
                using (var reader = await cmd.ExecuteReaderAsync()) 
                { 
                    while (await reader.ReadAsync())
                    { 
                        list.Add(new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID = reader.GetInt32(2) 
                        });
                    }
                }
            }
            return list;
        }


        public async Task AddAsync(Subject subject)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Subjects (SubjectName, CourseID) VALUES (@name, @courseId)", conn);
                cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Subject subject)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Subjects SET SubjectName = @name, CourseID = @courseId WHERE SubjectID = @id", conn);
                cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                cmd.Parameters.AddWithValue("@id", subject.SubjectID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}


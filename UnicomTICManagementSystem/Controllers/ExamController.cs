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
    internal class ExamController
    {
        public async Task<List<Exam>> GetAllAsync() 
        { 
            var list = new List<Exam>();
            using (var conn = DBConfig.GetConnection()) 
            { 
                var cmd = new SQLiteCommand("SELECT * FROM Exams", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                { 
                    while (await reader.ReadAsync())
                    { 
                        list.Add(new Exam
                        {
                            ExamId = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            SubjectID = reader.GetInt32(2) 
                        });
                    }
                } 
            }
            return list;
        }

        public async Task AddAsync(Exam exam)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName, SubjectID) VALUES (@name, @subjectId)", conn);
                cmd.Parameters.AddWithValue("@name", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Exam exam)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @name, SubjectID = @subjectId WHERE ExamID = @id", conn);
                cmd.Parameters.AddWithValue("@name", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                cmd.Parameters.AddWithValue("@id", exam.ExamId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}



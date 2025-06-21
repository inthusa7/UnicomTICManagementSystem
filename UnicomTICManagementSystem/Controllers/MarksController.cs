using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class MarksController
    {
        public async Task<List<Mark>> GetAllAsync() 
        {
            var list = new List<Mark>();
            using (var conn = DBConfig.GetConnection())
            { 
                var cmd = new SQLiteCommand("SELECT * FROM Marks", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    { 
                        list.Add(new Mark
                        {
                            MarkID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1), 
                            ExamID = reader.GetInt32(2),
                            Score = reader.GetInt32(3)
                        });
                    }
                }
            } 
            return list; 
        }

        public async Task<List<Mark>> GetMarksByStudentIdAsync(int studentId)
        {
            var allMarks = await GetAllAsync();
            return allMarks.Where(m => m.StudentID == studentId).ToList();
        }
        public async Task<DataTable> GetStudentMarksDetailedAsync(int studentId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
                SELECT 
                    c.CourseName,
                    s.SubjectName,
                    e.ExamName,
                    m.Score
                FROM Marks m
                INNER JOIN Students st ON m.StudentID = st.StudentID
                INNER JOIN Exams e ON m.ExamID = e.ExamID
                INNER JOIN Subjects s ON e.SubjectID = s.SubjectID
                INNER JOIN Courses c ON s.CourseID = c.CourseID
                WHERE st.StudentID = @id";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", studentId);

                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                await Task.Run(() => adapter.Fill(table));
                return table;
            }
        }



        public async Task AddAsync(Mark mark)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@sid, @eid, @score)", conn);
                cmd.Parameters.AddWithValue("@sid", mark.StudentID);
                cmd.Parameters.AddWithValue("@eid", mark.ExamID);
                cmd.Parameters.AddWithValue("@score", mark.Score);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Mark mark)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Marks SET StudentID = @sid, ExamID = @eid, Score = @score WHERE MarkID = @id", conn);
                cmd.Parameters.AddWithValue("@sid", mark.StudentID);
                cmd.Parameters.AddWithValue("@eid", mark.ExamID);
                cmd.Parameters.AddWithValue("@score", mark.Score);
                cmd.Parameters.AddWithValue("@id", mark.MarkID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int markId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Marks WHERE MarkID = @id", conn);
                cmd.Parameters.AddWithValue("@id", markId);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }


}
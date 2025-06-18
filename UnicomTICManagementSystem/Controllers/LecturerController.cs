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
    internal class LecturerController
    {
        public async Task<List<Lecturer>> GetAllAsync()
        {
            var list = new List<Lecturer>();
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Lecturers", conn);
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    list.Add(new Lecturer
                    {
                        LecturerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        CourseID = reader.GetInt32(3),
                        SubjectID = reader.GetInt32(4)
                    });
                }
            }
            return list;
        }

        public async Task AddAsync(Lecturer lecturer)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Lecturers (Name, Address, CourseID, SubjectID) VALUES (@n, @a, @c, @s)", conn);
                cmd.Parameters.AddWithValue("@n", lecturer.Name);
                cmd.Parameters.AddWithValue("@a", lecturer.Address);
                cmd.Parameters.AddWithValue("@c", lecturer.CourseID);
                cmd.Parameters.AddWithValue("@s", lecturer.SubjectID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Lecturer lecturer)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Lecturers SET Name=@n, Address=@a, CourseID=@c, SubjectID=@s WHERE LecturerID=@id", conn);
                cmd.Parameters.AddWithValue("@n", lecturer.Name);
                cmd.Parameters.AddWithValue("@a", lecturer.Address);
                cmd.Parameters.AddWithValue("@c", lecturer.CourseID);
                cmd.Parameters.AddWithValue("@s", lecturer.SubjectID);
                cmd.Parameters.AddWithValue("@id", lecturer.LecturerID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Lecturers WHERE LecturerID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}


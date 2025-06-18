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
    internal class TimetableController
    {
        public async Task<List<Timetable>> GetAllAsync() { var list = new List<Timetable>(); using (var conn = DBConfig.GetConnection()) { var cmd = new SQLiteCommand("SELECT * FROM Timetables", conn); using (var reader = await cmd.ExecuteReaderAsync()) { while (await reader.ReadAsync()) { list.Add(new Timetable { TimetableID = reader.GetInt32(0), SubjectID = reader.GetInt32(1), TimeSlot = reader.GetString(2), RoomID = reader.GetInt32(3) }); } } } return list; }
        
        public async Task AddAsync(Timetable timetable)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@sub, @slot, @room)", conn);
                cmd.Parameters.AddWithValue("@sub", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@slot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@room", timetable.RoomID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Timetable timetable)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Timetables SET SubjectID = @sub, TimeSlot = @slot, RoomID = @room WHERE TimetableID = @id", conn);
                cmd.Parameters.AddWithValue("@sub", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@slot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@room", timetable.RoomID);
                cmd.Parameters.AddWithValue("@id", timetable.TimetableID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Timetables WHERE TimetableID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        public async Task<DataTable> GetAllTimetablesAsync()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
            SELECT 
                s.SubjectName,
                c.CourseName,
                t.TimeSlot,
                r.RoomName,
                r.RoomType
            FROM Timetables t
            INNER JOIN Subjects s ON t.SubjectID = s.SubjectID
            INNER JOIN Courses c ON s.CourseID = c.CourseID
            INNER JOIN Rooms r ON t.RoomID = r.RoomID";

                var cmd = new SQLiteCommand(query, conn);
                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                await Task.Run(() => adapter.Fill(table));
                return table;
            }
        }
        public async Task<DataTable> GetTimetableForStudentAsync(int studentId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
            SELECT 
                s.SubjectName,
                c.CourseName,
                t.TimeSlot,
                r.RoomName,
                r.RoomType
            FROM Timetables t
            INNER JOIN Subjects s ON t.SubjectID = s.SubjectID
            INNER JOIN Courses c ON s.CourseID = c.CourseID
            INNER JOIN Rooms r ON t.RoomID = r.RoomID
            INNER JOIN Students st ON st.CourseID = c.CourseID
            WHERE st.StudentID = @studentId";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                await Task.Run(() => adapter.Fill(table));
                return table;
            }
        }
        public async Task<DataTable> GetTimetableByLecturerIdAsync(int lecturerId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
            SELECT 
                s.SubjectName,
                c.CourseName,
                t.TimeSlot,
                r.RoomName,
                r.RoomType
            FROM Timetables t
            INNER JOIN Subjects s ON t.SubjectID = s.SubjectID
            INNER JOIN Courses c ON s.CourseID = c.CourseID
            INNER JOIN Rooms r ON t.RoomID = r.RoomID
            INNER JOIN Lecturers l ON l.SubjectID = s.SubjectID
            WHERE l.LecturerID = @lecturerId";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@lecturerId", lecturerId);

                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                await Task.Run(() => adapter.Fill(table));
                return table;
            }
        }
    }
}
